using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<string[]> list = new List<string[]>();

        public Form1()
        {
            InitializeComponent();

            // ��������� �������� �� ����������� ������
            comboBox1.Items.Add("������ 1");
            comboBox1.Items.Add("������ 2");
            comboBox1.Items.Add("������ 3");
            comboBox1.Items.Add("��� �������"); 

            // ϳ��������� �� ��䳿 SelectedIndexChanged ������ ComboBox
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // ���������� ������ ������ (���������, � ����� ��� ��)
            // list = ... // ����� �� ��� ��� ���������� ������
        }


        private void Form1_load(object sender, EventArgs e)
        {
            listView1.Columns.Add("�����");
            listView1.Columns.Add("ֳ�� ");
            listView1.Columns.Add("���");

            // ��������� ������ ��� ����������� �����
            UpdateListView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ��������� ��������� �������� � ��������� ������ ��������
            string selectedFilter = comboBox1.SelectedItem.ToString();

            // ��������� ������
            UpdateListView(selectedFilter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ��������, �� �� ���� ��������
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("���� �����, �������� �� ����!");
                return;
            }

            // ��������� ������ �������� �� ������
            string[] newItem = new string[] { textBox1.Text, textBox2.Text, textBox3.Text };
            list.Add(newItem);

            // ��������� ������
            UpdateListView();

            // �������� ��������� ����
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // �������� ��������� ����
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // �������� ������ �� ��������� � ������ �������
            list.Clear();
            // ���������� ������ ������ (���������, � ����� ��� ��)
            // list = ... // ����� �� ��� ��� ���������� ������
            UpdateListView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // ������� ��������� ����������� ��� �������������� ��� �������� �������� �����
        }

        private void UpdateListView(string filterBy = null)
        {
            listView1.Items.Clear();

            foreach (string[] item in list)
            {
                if (filterBy == null || filterBy == "��� �������" || item[2] == filterBy) // Գ�������� �� ��������� � ������� "���"
                {
                    ListViewItem newItem = new ListViewItem(item);
                    listView1.Items.Add(newItem);
                }
            }
        }
    }
}
