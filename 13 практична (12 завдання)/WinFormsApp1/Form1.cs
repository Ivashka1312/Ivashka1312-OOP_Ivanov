namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // ������ ����� �������� �� regionComboBox
            regionComboBox.Items.AddRange(new object[] {
        "³�������", "���������", "���������������", "��������", "�����������",
        "������������", "���������", "�����-����������", "�������", "ʳ������������",
        "���������", "��������", "�����������", "�������", "����������",
        "г��������", "�������", "������������", "���������", "����������",
        "�����������", "���������", "����������", "����������"});

            // ������ ����� ��� �� cityComboBox
            cityComboBox.Items.AddRange(new object[] {
        "���", "�����", "�����", "�����", "�������", "��������",
        "����", "������ г�", "�������", "³�����", "�������", "�������",
        "�������", "������", "�������", "�����-���������",
        "���'�����-����������", "������", "������������", "����",
        "г���", "��������", "�������", "�����" });


        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ��������� ������� � ���� ��������
            string region = regionComboBox.Text;
            string city = cityComboBox.Text;
            string postalCode = postalCodeTextBox.Text;
            string address = addressTextBox.Text;

            // �������� ����
            if (string.IsNullOrWhiteSpace(region) || string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(postalCode) || string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("���� �����, �������� �� ����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (postalCode.Length != 6 || !postalCode.All(char.IsDigit))
            {
                MessageBox.Show("������������ ������ ��������� ����. ������� ���� 6 ����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (address.Length < 5)
            {
                MessageBox.Show("������������ ������ ������. ������ ������� ������ �������� 5 �������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // �� ��� ������ ��������, �������� �� � MessageBox
            string message = $"�������: {region}\n̳���: {city}\n�������� ���: {postalCode}\n������: {address}";
            MessageBox.Show(message, "������ ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
