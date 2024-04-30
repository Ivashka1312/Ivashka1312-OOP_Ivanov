using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private string filePath = "dictionary.txt"; // ��������� ���������� filePath ����

        public Form1()
        {
            InitializeComponent();
            LoadDictionaryFromFile();
            foreach (var pair in dictionary)
            {
                listView1.Items.Add($"{pair.Key} - {pair.Value}");
            }
        }





        private void FindTranslationButton_Click(object sender, EventArgs e)
        {
            string word = wordTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(word))
            {
                if (dictionary.ContainsKey(word))
                {
                    MessageBox.Show($"�������� ����� '{word}': {dictionary[word]}");
                }
                else
                {
                    MessageBox.Show("�������� ��� ����� ����� �� ��������.");
                }
            }
            else
            {
                MessageBox.Show("���� �����, ������ ����� ��� ������ ���������.");
            }
        }

       

        private void LoadDictionaryFromFile()
        {
            string filePath = "dictionary.txt"; // ���� �� ����� ��������

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string word = parts[0];
                            string translation = parts[1];
                            if (!dictionary.ContainsKey(word))
                            {
                                dictionary.Add(word, translation);
                            }
                        }
                    }

                    MessageBox.Show("������� ������ ����������� � �����.");
                }
                else
                {
                    MessageBox.Show("���� �������� �� ��������. ����� ������� ���� ��������.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� �������: {ex.Message}");
            }
        }

        private void AddWordButton_Click_1(object sender, EventArgs e)
        {

            string word = wordTextBox.Text.Trim();
            string translation = translationTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(translation))
            {

                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, translation);
                    MessageBox.Show("����� �� ���� �������� ������ ����� �� ��������.");
                    wordTextBox.Text = ""; // ������� ������� ����
                    translationTextBox.Text = "";
                }
                else
                {
                    MessageBox.Show("�� ����� ��� ���� � ��������.");
                }
            }
            else
            {
                MessageBox.Show("���� �����, ������ ����� �� ���� ��������.");
            }
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var pair in dictionary)
                {
                    writer.WriteLine($"{pair.Key}:{pair.Value}");
                }
            }

            MessageBox.Show("������� ������ ��������� � ����.");
        }
    }
}
