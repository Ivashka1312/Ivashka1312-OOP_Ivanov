namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtPort = new TextBox();
            label2 = new Label();
            txtRootFolder = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            txtLog = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 45);
            label1.Name = "label1";
            label1.Size = new Size(48, 20);
            label1.TabIndex = 0;
            label1.Text = "Порт ";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(95, 82);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 45);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(125, 20);
            label2.TabIndex = 2;
            label2.Text = "Коренева папка:";
            // 
            // txtRootFolder
            // 
            txtRootFolder.Location = new Point(282, 82);
            txtRootFolder.Name = "txtRootFolder";
            txtRootFolder.Size = new Size(125, 27);
            txtRootFolder.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(109, 136);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(300, 136);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(95, 237);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(582, 27);
            txtLog.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 199);
            label3.Name = "label3";
            label3.Size = new Size(350, 20);
            label3.TabIndex = 7;
            label3.Text = "Відображення повідомлень про роботу сервера";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtLog);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtRootFolder);
            Controls.Add(label2);
            Controls.Add(txtPort);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPort;
        private Label label2;
        private TextBox txtRootFolder;
        private Button btnStart;
        private Button btnStop;
        private TextBox txtLog;
        private Label label3;
    }
}
