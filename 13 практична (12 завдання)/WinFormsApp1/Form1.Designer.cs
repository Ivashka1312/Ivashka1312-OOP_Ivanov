using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
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
            button1 = new Button();
            cityComboBox = new ComboBox();
            postalCodeTextBox = new TextBox();
            addressTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label1 = new Label();
            regionComboBox = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(112, 298);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Зберегти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cityComboBox
            // 
            cityComboBox.FormattingEnabled = true;
            cityComboBox.Location = new Point(382, 78);
            cityComboBox.Name = "cityComboBox";
            cityComboBox.Size = new Size(200, 28);
            cityComboBox.TabIndex = 2;
            // 
            // postalCodeTextBox
            // 
            postalCodeTextBox.Location = new Point(112, 208);
            postalCodeTextBox.Name = "postalCodeTextBox";
            postalCodeTextBox.Size = new Size(200, 27);
            postalCodeTextBox.TabIndex = 3;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(382, 208);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(200, 27);
            addressTextBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(382, 46);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 6;
            label2.Text = "Місто";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 175);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 7;
            label3.Text = "Поштовий індекс";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(382, 175);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 8;
            label4.Text = "Адреса";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 46);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 9;
            label1.Text = "Область";
            // 
            // regionComboBox
            // 
            regionComboBox.FormattingEnabled = true;
            regionComboBox.Location = new Point(112, 78);
            regionComboBox.Name = "regionComboBox";
            regionComboBox.Size = new Size(200, 28);
            regionComboBox.TabIndex = 1;
            regionComboBox.SelectedIndexChanged += regionComboBox_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(addressTextBox);
            Controls.Add(postalCodeTextBox);
            Controls.Add(cityComboBox);
            Controls.Add(regionComboBox);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ComboBox cityComboBox;
        private TextBox postalCodeTextBox;
        private TextBox addressTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label1;
        private ComboBox regionComboBox;
    }
}
