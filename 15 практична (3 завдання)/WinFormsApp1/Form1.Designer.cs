using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox wordTextBox;
        private TextBox translationTextBox;
        private Button AddWordButton;
        private Button FindTranslationButton;
        private Button SaveButton;


        private void InitializeComponent()
        {
            wordTextBox = new TextBox();
            translationTextBox = new TextBox();
            AddWordButton = new Button();
            FindTranslationButton = new Button();
            SaveButton = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // wordTextBox
            // 
            wordTextBox.Location = new Point(80, 108);
            wordTextBox.Name = "wordTextBox";
            wordTextBox.Size = new Size(125, 27);
            wordTextBox.TabIndex = 0;
            // 
            // translationTextBox
            // 
            translationTextBox.Location = new Point(229, 108);
            translationTextBox.Name = "translationTextBox";
            translationTextBox.Size = new Size(125, 27);
            translationTextBox.TabIndex = 1;
            // 
            // AddWordButton
            // 
            AddWordButton.Location = new Point(95, 151);
            AddWordButton.Name = "AddWordButton";
            AddWordButton.Size = new Size(94, 29);
            AddWordButton.TabIndex = 2;
            AddWordButton.Text = "Додати слово";
            AddWordButton.UseVisualStyleBackColor = true;
            AddWordButton.Click += AddWordButton_Click_1;
            // 
            // FindTranslationButton
            // 
            FindTranslationButton.Location = new Point(241, 151);
            FindTranslationButton.Name = "FindTranslationButton";
            FindTranslationButton.Size = new Size(94, 29);
            FindTranslationButton.TabIndex = 3;
            FindTranslationButton.Text = "Знайти переклад";
            FindTranslationButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(390, 151);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 4;
            SaveButton.Text = "Зберегти словник";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click_1;
            // 
            // listView1
            // 
            listView1.Location = new Point(390, 14);
            listView1.Name = "listView1";
            listView1.Size = new Size(151, 121);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            ClientSize = new Size(586, 282);
            Controls.Add(listView1);
            Controls.Add(SaveButton);
            Controls.Add(FindTranslationButton);
            Controls.Add(AddWordButton);
            Controls.Add(translationTextBox);
            Controls.Add(wordTextBox);
            Name = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        private ListView listView1;
       
    }
}
