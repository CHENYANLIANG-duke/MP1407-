using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace MP1407
{
    public partial class Form1 : Form
    {
        int M_iResult;
        List<byte> devcomport = new List<byte>();
        List<byte> devcomport2 = new List<byte>();
        string[] ports;
        string strUID;
        private byte[] Key = new byte[(int)RDINT.MIFARE_ONE_DEF.CARD_KEY_LEN];

        Thread thread0;
        Thread thread1;
        Thread thread2;
        Thread TagDataProcess;

        byte[] Data;
        byte[] Data2;
        byte[] DataURL1;
        byte[] DataURL2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readconfig();
        }

        private void btn_OpenReader_Click(object sender, EventArgs e)
        {
            uint intBar = 0;
            txtmsg.Clear();

            for (int i = 0; i < ports.Length; i++)
            {
                var comindex = Convert.ToInt32(ports[i].Remove(0, 3));
                devcomport.Add((byte)comindex);
            }

            for (int i = 0; i < devcomport.Count; i++)
            {
                M_iResult = (int)RDINT.RDINTsys.OpenReader(devcomport[i], uint.Parse("38400"), "00000000", RDINT.TURN_ON_OFF.TURN_ON, uint.Parse("0"), out intBar);
                if (!(M_iResult == 0))
                {
                    ShowStatus("Open Reader" + (i + 1).ToString() + " 失敗。錯誤代碼:" + M_iResult);
                }
                else
                {
                    ShowStatus("Open Reader  com" + devcomport[i].ToString() + " 成功");
                    devcomport2.Add((byte)devcomport[i]);
                }
            }

            btn_OpenReader.Enabled = false;
            btn_CloseReader.Enabled = true;
            btn_AutoReadUltraLight.Enabled = true;

        }

        private void btn_CloseReader_Click(object sender, EventArgs e)
        {
            try
            {
                txtmsg.Clear();

                for (int i = 0; i < devcomport2.Count; i++)
                {
                    M_iResult = (int)RDINT.RDINTsys.CloseReader(devcomport2[i]);


                    if (M_iResult == 0)
                    {
                        ShowStatus("Close Reader" + (i + 1).ToString() + "成功");
                    }
                    else
                        ShowStatus("Close Reader" + (i + 1).ToString() + " 失敗。錯誤代碼:");
                }

                thread0.Suspend();
                thread1.Suspend();
                thread2.Suspend();
                TagDataProcess.Suspend();

            }
            catch (Exception ex)
            {
                MessageBox.Show("請確認設備連線狀態");
            }

            btn_CloseReader.Enabled = false;
            btn_OpenReader.Enabled = true;
            btn_AutoReadUltraLight.Enabled = true;
        }

        private void btn_AutoReadUltraLight_Click(object sender, EventArgs e)
        {
          
            thread0 = new Thread(readNFC);
            thread0.Start(0);

            thread1 = new Thread(readNFC);
            thread1.Start(1);

            thread2 = new Thread(readNFC);
            thread2.Start(2);


            TagDataProcess = new Thread(Dataprocess);
            TagDataProcess.Start();


            btn_AutoReadUltraLight.Enabled = false;

            BeginInvoke((Action)delegate
            {
                txtmsg.Clear();
            });
        }

        private void ShowStatus(String Msg)
        {
            txtmsg.Text += Msg + "\r\n";
        }

        private void readconfig()
        {
            string path = Directory.GetCurrentDirectory() + @"\configer.ini";
            StreamReader sr = new StreamReader(path);
            string port = sr.ReadToEnd();
            ports = port.Split(',');
            sr.Close();
        }

        private void writedata(string data)
        {
            if (data.Length > (Convert.ToInt32(txtUID.Text) + Convert.ToInt32(txtLOT.Text) + Convert.ToInt32(txtUrl.Text)))
            {
                string path = Directory.GetCurrentDirectory() + @"\ndef.txt";
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        private void btn_CloseReader_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void readNFC(object comNo)
        {
            while (true)
            {
                try
                {
                    //GET UID
                    int i, j;
                    byte Sak;
                    byte[] Uid = new byte[(int)RDINT.OPENCARD_DEF.UID_LEN];
                    byte[] Atqa = new byte[(int)RDINT.OPENCARD_DEF.ATQA_LEN];

                    strUID = "";

                    //u1AutoFind設定TURN_ON，卡片關閉後必須重新靠卡，才可開啟卡片
                    M_iResult = (int)RDINT.RDINTnon.OpenCard(devcomport2[(int)comNo], (RDINT.TURN_ON_OFF)RDINT.TURN_ON_OFF.TURN_ON, Uid, Atqa, out Sak);

                    for (i = (int)RDINT.OPENCARD_DEF.UID_LEN - 1; i >= 0; i -= 1)
                    {
                        if (Uid[i] == (int)RDINT.OPENCARD_DEF.UID_END)
                            break;
                    }

                    j = i;

                    for (i = 0; i < j; i++)
                    {
                        strUID += Uid[i].ToString("X2");
                    }

                    if (strUID.Length == Convert.ToInt32(txtUID.Text))
                    {
                        // GET URL
                        //依指定的區塊(Block)位置，讀取UltraLight卡片內的資料
                        Data = new byte[(int)RDINT.ULTRA_LIGHT.ULTRA_LIGHT_READ_LEN];
                        Data2 = new byte[(int)RDINT.ULTRA_LIGHT.ULTRA_LIGHT_READ_LEN];
                        DataURL1 = new byte[(int)RDINT.ULTRA_LIGHT.ULTRA_LIGHT_READ_LEN];
                        DataURL2 = new byte[(int)RDINT.ULTRA_LIGHT.ULTRA_LIGHT_READ_LEN];

                        //block 5  ,16 byte
                        RDINT.RDINTnon.ReadUltraLight(devcomport2[(int)comNo], 6, Data);
                        RDINT.RDINTnon.ReadUltraLight(devcomport2[(int)comNo], 10, Data2);
                        RDINT.RDINTnon.ReadUltraLight(devcomport2[(int)comNo], 15, DataURL1);
                        RDINT.RDINTnon.ReadUltraLight(devcomport2[(int)comNo], 19, DataURL2);
                    }                
                }
                catch (Exception ex) { }

                //  Thread.Sleep(Convert.ToInt32(textBox1.Text));
                Thread.Sleep(1);
            }
        }

        private void Dataprocess()
        {
            while (true)
            {
                if (Data != null && Data2 != null && DataURL1 != null && DataURL2 != null)
                {
                    byte[] newdata1 = new byte[15];
                    byte[] newdata2 = new byte[5];
                    byte[] newURL1 = new byte[13];

                    //Array.Copy(a, 2, b, 0, 3); //从a的第二个开始复制到b的第0个，一共复制三个元素
                    Array.Copy(Data, 1, newdata1, 0, 15);
                    Array.Copy(Data2, 0, newdata2, 0, 5);
                    Array.Copy(DataURL1, 3, newURL1, 0, 13);

                    string lotno = Encoding.ASCII.GetString(newdata1) + Encoding.ASCII.GetString(newdata2);

                    if (lotno.Length == Convert.ToInt32(txtLOT.Text))
                    {
                        string strurl = Encoding.ASCII.GetString(newURL1);

                        //正規表示url
                        List<String> rzList = new List<String>();
                        Match match = Regex.Match(Encoding.ASCII.GetString(DataURL2), @"[a-zA-Z0-9\./_]+");

                        for (int x = 0; match.Success; x++)
                        {
                            rzList.Add(match.Groups[0].Value);
                            match = match.NextMatch();
                        }

                        for (int x = 0; x < rzList.Count; x++)
                        {
                            strurl += rzList[x];
                        }

                        if (strurl.Length == Convert.ToInt32(txtUrl.Text))
                        {
                            string dataout = "";

                            dataout = lotno.Trim('\0') + "\t" + strUID.Trim('\0') + "\t" + strurl.Trim('\0');

                            writedata(dataout);

                            BeginInvoke((Action)delegate
                            {
                                txtmsg.Text = strUID;
                            });
                        }
                    }
                }
               
                Thread.Sleep(Convert.ToInt32(textBox1.Text));
            }

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
          
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }
    }
}
