using System.Net.Sockets; // This imports 'System.Net' as well
using System.Net;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private int port;
        private string rootFolder;

        public Form1()
        {
            InitializeComponent();

            port = 8080; // Задаємо порт за замовчуванням
            rootFolder = Directory.GetCurrentDirectory(); // Поточна папка як коренева
            server = new TcpListener(IPAddress.Any, port);                                //  this.SuspendLayout();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Спробуємо отримати значення з поля порту та кореневої папки
                port = int.Parse(txtPort.Text);
                rootFolder = txtRootFolder.Text;

                // Створити TCPListener
                server = new TcpListener(IPAddress.Any, port);

                // Запустити сервер
                server.Start();

                // Вивести повідомлення про запуск сервера
                txtLog.AppendText("Сервер запущено на порту " + port + "!\n");

                // Очікувати підключень
                 StartListening();
            }
            catch (Exception ex)
            {
                // Вивести повідомлення про помилку
                txtLog.AppendText("Помилка: " + ex.Message + "\n");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Зупинити сервер
            StopServer();
        }
        private void StartListening()
        {
            while (true)
            {
                try
                {
                    // Очікувати підключення клієнта
                    TcpClient client = server.AcceptTcpClient();

                    // Отримати потік вводу та виводу клієнта
                    NetworkStream stream = client.GetStream();

                    // Отримати запит HTTP від клієнта
                    string request = ReadRequest(stream);

                    // Обробити запит HTTP
                    HandleRequest(request, stream);

                    // Закрити потік
                    stream.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    // Вивести повідомлення про помилку
                    txtLog.AppendText("Помилка під час обробки запиту: " + ex.Message + "\n");
                }
            }
        }

        private string ReadRequest(NetworkStream stream)
        {
            // Створити буфер для читання запиту
            byte[] buffer = new byte[1024];

            // Читати запит до буфера
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            // Перетворити буфер на рядок
            string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Повернути рядок запиту
            return request;
        }

        private void HandleRequest(string request, NetworkStream stream)
        {
            // Розбити рядок запиту на частини
            string[] parts = request.Split(' ');

            // Отримати метод HTTP (GET, POST, ...)
            string method = parts[0];

            // Отримати шлях до ресурсу
            string path = parts[1];

            // Сформувати шлях до файлу в кореневій папці
            string filePath = Path.Combine(rootFolder, path.TrimStart('/'));

            // Перевірити, чи існує файл
            if (File.Exists(filePath))
            {
                // Відкрити файл для читання
                string fileStream = File.ReadAllText(filePath, Encoding.UTF8);

                // Створити відповідь HTTP
                string response = CreateResponse(fileStream, method);

                // Відправити відповідь HTTP клієнту
                SendResponse(response, stream);
            }
            else
            {
                // Відправити відповідь 404 Not Found
                string response = CreateErrorResponse("404 Not Found", method);
                SendResponse(response, stream);
            }
        }

        private string CreateResponse(string fileStream, string method)
        {
            // Отримати розмір файлу
            long contentLength = fileStream.Length;

            // Визначити тип контенту залежно від розширення файлу
            string contentType = "text/html";

            // Створити рядок стану HTTP (наприклад, 200 OK)
            string statusLine = "HTTP/1.1 200 OK";

            // Сформувати заголовки відповіді
            StringBuilder headers = new StringBuilder();
            headers.AppendLine("Server: SimpleHttpServer/1.0");
            headers.AppendLine("Content-Type: " + contentType);
            headers.AppendLine("Content-Length: " + contentLength);
            headers.AppendLine(""); // Пустий рядок для завершення заголовків

            // Скомпонувати відповідь HTTP
            string response = statusLine + "\r\n" + headers.ToString() + "\r\n" + fileStream;

            // Додати вміст файлу до відповіді


            // Повернути відповідь HTTP
            return response;
        }

        private string CreateErrorResponse(string errorMessage, string method)
        {
            // Створити рядок стану HTTP (наприклад, 404 Not Found)
            string statusLine = "HTTP/1.1 400 Bad Request";

            // Сформувати заголовки відповіді
            StringBuilder headers = new StringBuilder();
            headers.AppendLine("Server: SimpleHttpServer/1.0");
            headers.AppendLine("Content-Type: text/plain"); // Текстовий вміст помилки
            headers.AppendLine(""); // Пустий рядок для завершення заголовків

            // Скомпонувати відповідь HTTP з повідомленням про помилку
            string response = statusLine + "\r\n" + headers.ToString() + "\r\n" + errorMessage;

            // Повернути відповідь HTTP
            return response;
        }

        private string GetContentType(string extension)
        {
            // Словник для співставлення розширень файлів з типами контенту
            Dictionary<string, string> contentTypes = new Dictionary<string, string>()
            {
                { ".html", "text/html" },
                { ".txt", "text/plain" },
                { ".css", "text/css" },
                { ".js", "application/javascript" },
                { ".jpg", "image/jpeg" },
                { ".png", "image/png" },
                // ... Додати інші розширення за потребою
            };

            // Отримати тип контенту за розширенням
            string contentType;
            if (contentTypes.TryGetValue(extension.ToLower(), out contentType))
            {
                return contentType;
            }
            else
            {
                // За замовчуванням - application/octet-stream
                return "application/octet-stream";
            }
        }

        private void SendResponse(string response, NetworkStream stream)
        {
            // Перетворити відповідь HTTP на масив байтів
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            // Відправити масив байтів клієнту
            stream.Write(responseBytes, 0, responseBytes.Length);
            stream.Flush();
        }

        private void StopServer()
        {
            if (server != null)
            {
                server.Stop();
                txtLog.AppendText("Сервер зупинено.\n");
            }
        }
    }
}

