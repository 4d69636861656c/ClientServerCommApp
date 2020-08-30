namespace ClientServerCommApp
{
    partial class SRFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IP = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listen = new System.Windows.Forms.Button();
            this.idlelisten = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(104, 28);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(209, 20);
            this.IP.TabIndex = 0;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(104, 54);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(209, 20);
            this.Port.TabIndex = 1;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(104, 80);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(142, 20);
            this.txtFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select File";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 20);
            this.button1.TabIndex = 6;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 121);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listen
            // 
            this.listen.Location = new System.Drawing.Point(252, 121);
            this.listen.Name = "listen";
            this.listen.Size = new System.Drawing.Size(61, 23);
            this.listen.TabIndex = 8;
            this.listen.Text = "Start listening";
            this.listen.UseVisualStyleBackColor = true;
            this.listen.Visible = false;
            this.listen.Click += new System.EventHandler(this.listen_Click);
            // 
            // idlelisten
            // 
            this.idlelisten.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.idlelisten.Location = new System.Drawing.Point(15, 161);
            this.idlelisten.Name = "idlelisten";
            this.idlelisten.Size = new System.Drawing.Size(298, 32);
            this.idlelisten.TabIndex = 9;
            this.idlelisten.Text = "While this windows is opened, you can also receive files from connected clients. " +
    "Tread carefully!";
            this.idlelisten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.idlelisten.Click += new System.EventHandler(this.idlelisten_Click);
            // 
            // SRFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 191);
            this.Controls.Add(this.idlelisten);
            this.Controls.Add(this.listen);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IP);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 230);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(345, 230);
            this.Name = "SRFiles";
            this.Text = "Sharing Center";
            this.Load += new System.EventHandler(this.SRFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button listen;
        private System.Windows.Forms.Label idlelisten;
    }
}