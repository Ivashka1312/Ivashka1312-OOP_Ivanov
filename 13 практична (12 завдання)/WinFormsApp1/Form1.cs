namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Додати назви областей до regionComboBox
            regionComboBox.Items.AddRange(new object[] {
        "Вінницька", "Волинська", "Дніпропетровська", "Донецька", "Житомирська",
        "Закарпатська", "Запорізька", "Івано-Франківська", "Київська", "Кіровоградська",
        "Луганська", "Львівська", "Миколаївська", "Одеська", "Полтавська",
        "Рівненська", "Сумська", "Тернопільська", "Харківська", "Херсонська",
        "Хмельницька", "Черкаська", "Чернівецька", "Чернігівська"});

            // Додати назви міст до cityComboBox
            cityComboBox.Items.AddRange(new object[] {
        "Київ", "Харків", "Одеса", "Дніпро", "Донецьк", "Запоріжжя",
        "Львів", "Кривий Ріг", "Миколаїв", "Вінниця", "Черкаси", "Житомир",
        "Полтава", "Чернігів", "Чернівці", "Івано-Франківськ",
        "Кам'янець-Подільський", "Херсон", "Хмельницький", "Суми",
        "Рівне", "Тернопіль", "Ужгород", "Луцьк" });


        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Отримання значень з полів введення
            string region = regionComboBox.Text;
            string city = cityComboBox.Text;
            string postalCode = postalCodeTextBox.Text;
            string address = addressTextBox.Text;

            // Валідація полів
            if (string.IsNullOrWhiteSpace(region) || string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (postalCode.Length != 6 || !postalCode.All(char.IsDigit))
            {
                MessageBox.Show("Неправильний формат поштового коду. Повинно бути 6 цифр.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (address.Length < 5)
            {
                MessageBox.Show("Неправильний формат адреси. Адреса повинна містити принаймні 5 символів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Всі дані введені коректно, виводимо їх у MessageBox
            string message = $"Область: {region}\nМісто: {city}\nПоштовий код: {postalCode}\nАдреса: {address}";
            MessageBox.Show(message, "Введені дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
