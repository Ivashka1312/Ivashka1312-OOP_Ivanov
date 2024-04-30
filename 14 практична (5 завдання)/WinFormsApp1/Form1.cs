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

            // Додавання елементів до випадаючого списку
            comboBox1.Items.Add("Варіант 1");
            comboBox1.Items.Add("Варіант 2");
            comboBox1.Items.Add("Варіант 3");
            comboBox1.Items.Add("Без фільтра"); 

            // Підключення до події SelectedIndexChanged вашого ComboBox
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Заповнення списку даними (наприклад, з файлу або БД)
            // list = ... // Заміна на ваш код заповнення списку
        }


        private void Form1_load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Назва");
            listView1.Columns.Add("Ціна ");
            listView1.Columns.Add("Тип");

            // Оновлення списку при завантаженні форми
            UpdateListView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Отримання вибраного значення і оновлення списку елементів
            string selectedFilter = comboBox1.SelectedItem.ToString();

            // Оновлення списку
            UpdateListView(selectedFilter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка, чи всі поля заповнені
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!");
                return;
            }

            // Додавання нового елемента до списку
            string[] newItem = new string[] { textBox1.Text, textBox2.Text, textBox3.Text };
            list.Add(newItem);

            // Оновлення списку
            UpdateListView();

            // Очищення текстових полів
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Очищення текстових полів
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Очищення списку та оновлення з повним списком
            list.Clear();
            // Заповнення списку даними (наприклад, з файлу або БД)
            // list = ... // Заміна на ваш код заповнення списку
            UpdateListView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Можливе додавання функціоналу для автодоповнення або валідації введених даних
        }

        private void UpdateListView(string filterBy = null)
        {
            listView1.Items.Clear();

            foreach (string[] item in list)
            {
                if (filterBy == null || filterBy == "Без фільтра" || item[2] == filterBy) // Фільтрація за значенням у колонці "Тип"
                {
                    ListViewItem newItem = new ListViewItem(item);
                    listView1.Items.Add(newItem);
                }
            }
        }
    }
}
