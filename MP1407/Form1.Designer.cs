namespace MP1407
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_CloseReader = new System.Windows.Forms.Button();
            this.btn_OpenReader = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmsg = new System.Windows.Forms.TextBox();
            this.btn_AutoReadUltraLight = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLOT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_CloseReader
            // 
            this.btn_CloseReader.Enabled = false;
            this.btn_CloseReader.Location = new System.Drawing.Point(110, 12);
            this.btn_CloseReader.Name = "btn_CloseReader";
            this.btn_CloseReader.Size = new System.Drawing.Size(86, 29);
            this.btn_CloseReader.TabIndex = 94;
            this.btn_CloseReader.Text = "Close Reader";
            this.btn_CloseReader.UseVisualStyleBackColor = true;
            this.btn_CloseReader.SizeChanged += new System.EventHandler(this.btn_CloseReader_SizeChanged);
            this.btn_CloseReader.Click += new System.EventHandler(this.btn_CloseReader_Click);
            // 
            // btn_OpenReader
            // 
            this.btn_OpenReader.Location = new System.Drawing.Point(18, 12);
            this.btn_OpenReader.Name = "btn_OpenReader";
            this.btn_OpenReader.Size = new System.Drawing.Size(86, 29);
            this.btn_OpenReader.TabIndex = 96;
            this.btn_OpenReader.Text = "Open Reader";
            this.btn_OpenReader.UseVisualStyleBackColor = true;
            this.btn_OpenReader.Click += new System.EventHandler(this.btn_OpenReader_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtmsg);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 105);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NDEF Message";
            // 
            // txtmsg
            // 
            this.txtmsg.Location = new System.Drawing.Point(6, 21);
            this.txtmsg.Multiline = true;
            this.txtmsg.Name = "txtmsg";
            this.txtmsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtmsg.Size = new System.Drawing.Size(376, 75);
            this.txtmsg.TabIndex = 97;
            // 
            // btn_AutoReadUltraLight
            // 
            this.btn_AutoReadUltraLight.Enabled = false;
            this.btn_AutoReadUltraLight.Location = new System.Drawing.Point(202, 11);
            this.btn_AutoReadUltraLight.Name = "btn_AutoReadUltraLight";
            this.btn_AutoReadUltraLight.Size = new System.Drawing.Size(120, 30);
            this.btn_AutoReadUltraLight.TabIndex = 94;
            this.btn_AutoReadUltraLight.Text = "AutoRead UltraLight";
            this.btn_AutoReadUltraLight.UseVisualStyleBackColor = true;
            this.btn_AutoReadUltraLight.Click += new System.EventHandler(this.btn_AutoReadUltraLight_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(202, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(55, 22);
            this.textBox1.TabIndex = 98;
            this.textBox1.Text = "10";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 99;
            this.label1.Text = "Thread time :";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Unitech NFC";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 101;
            this.label2.Text = "UID :";
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(59, 56);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(55, 22);
            this.txtUID.TabIndex = 100;
            this.txtUID.Text = "14";
            this.txtUID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 103;
            this.label3.Text = "LOT :";
            // 
            // txtLOT
            // 
            this.txtLOT.Location = new System.Drawing.Point(59, 83);
            this.txtLOT.Name = "txtLOT";
            this.txtLOT.Size = new System.Drawing.Size(55, 22);
            this.txtLOT.TabIndex = 102;
            this.txtLOT.Text = "20";
            this.txtLOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 12);
            this.label4.TabIndex = 105;
            this.label4.Text = "Url :";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(202, 56);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(55, 22);
            this.txtUrl.TabIndex = 104;
            this.txtUrl.Text = "16";
            this.txtUrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 223);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLOT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_AutoReadUltraLight);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_CloseReader);
            this.Controls.Add(this.btn_OpenReader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mp1407_Unitech v1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btn_CloseReader;
        internal System.Windows.Forms.Button btn_OpenReader;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btn_AutoReadUltraLight;
        private System.Windows.Forms.TextBox txtmsg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLOT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUrl;
    }
}

