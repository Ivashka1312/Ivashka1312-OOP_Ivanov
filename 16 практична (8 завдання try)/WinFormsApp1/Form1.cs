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

            port = 8080; // ������ ���� �� �������������
            rootFolder = Directory.GetCurrentDirectory(); // ������� ����� �� ��������
            server = new TcpListener(IPAddress.Any, port);                                //  this.SuspendLayout();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                // �������� �������� �������� � ���� ����� �� �������� �����
                port = int.Parse(txtPort.Text);
                rootFolder = txtRootFolder.Text;

                // �������� TCPListener
                server = new TcpListener(IPAddress.Any, port);

                // ��������� ������
                server.Start();

                // ������� ����������� ��� ������ �������
                txtLog.AppendText("������ �������� �� ����� " + port + "!\n");

                // ��������� ���������
                 StartListening();
            }
            catch (Exception ex)
            {
                // ������� ����������� ��� �������
                txtLog.AppendText("�������: " + ex.Message + "\n");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // �������� ������
            StopServer();
        }
        private void StartListening()
        {
            while (true)
            {
                try
                {
                    // ��������� ���������� �볺���
                    TcpClient client = server.AcceptTcpClient();

                    // �������� ���� ����� �� ������ �볺���
                    NetworkStream stream = client.GetStream();

                    // �������� ����� HTTP �� �볺���
                    string request = ReadRequest(stream);

                    // �������� ����� HTTP
                    HandleRequest(request, stream);

                    // ������� ����
                    stream.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    // ������� ����������� ��� �������
                    txtLog.AppendText("������� �� ��� ������� ������: " + ex.Message + "\n");
                }
            }
        }

        private string ReadRequest(NetworkStream stream)
        {
            // �������� ����� ��� ������� ������
            byte[] buffer = new byte[1024];

            // ������ ����� �� ������
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            // ����������� ����� �� �����
            string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // ��������� ����� ������
            return request;
        }

        private void HandleRequest(string request, NetworkStream stream)
        {
            // ������� ����� ������ �� �������
            string[] parts = request.Split(' ');

            // �������� ����� HTTP (GET, POST, ...)
            string method = parts[0];

            // �������� ���� �� �������
            string path = parts[1];

            // ���������� ���� �� ����� � �������� �����
            string filePath = Path.Combine(rootFolder, path.TrimStart('/'));

            // ���������, �� ���� ����
            if (File.Exists(filePath))
            {
                // ³������ ���� ��� �������
                string fileStream = File.ReadAllText(filePath, Encoding.UTF8);

                // �������� ������� HTTP
                string response = CreateResponse(fileStream, method);

                // ³�������� ������� HTTP �볺���
                SendResponse(response, stream);
            }
            else
            {
                // ³�������� ������� 404 Not Found
                string response = CreateErrorResponse("404 Not Found", method);
                SendResponse(response, stream);
            }
        }

        private string CreateResponse(string fileStream, string method)
        {
            // �������� ����� �����
            long contentLength = fileStream.Length;

            // ��������� ��� �������� ������� �� ���������� �����
            string contentType = "text/html";

            // �������� ����� ����� HTTP (���������, 200 OK)
            string statusLine = "HTTP/1.1 200 OK";

            // ���������� ��������� ������
            StringBuilder headers = new StringBuilder();
            headers.AppendLine("Server: SimpleHttpServer/1.0");
            headers.AppendLine("Content-Type: " + contentType);
            headers.AppendLine("Content-Length: " + contentLength);
            headers.AppendLine(""); // ������ ����� ��� ���������� ���������

            // ������������ ������� HTTP
            string response = statusLine + "\r\n" + headers.ToString() + "\r\n" + fileStream;

            // ������ ���� ����� �� ������


            // ��������� ������� HTTP
            return response;
        }

        private string CreateErrorResponse(string errorMessage, string method)
        {
            // �������� ����� ����� HTTP (���������, 404 Not Found)
            string statusLine = "HTTP/1.1 400 Bad Request";

            // ���������� ��������� ������
            StringBuilder headers = new StringBuilder();
            headers.AppendLine("Server: SimpleHttpServer/1.0");
            headers.AppendLine("Content-Type: text/plain"); // ��������� ���� �������
            headers.AppendLine(""); // ������ ����� ��� ���������� ���������

            // ������������ ������� HTTP � ������������ ��� �������
            string response = statusLine + "\r\n" + headers.ToString() + "\r\n" + errorMessage;

            // ��������� ������� HTTP
            return response;
        }

        private string GetContentType(string extension)
        {
            // ������� ��� ������������ ��������� ����� � ������ ��������
            Dictionary<string, string> contentTypes = new Dictionary<string, string>()
            {
                { ".html", "text/html" },
                { ".txt", "text/plain" },
                { ".css", "text/css" },
                { ".js", "application/javascript" },
                { ".jpg", "image/jpeg" },
                { ".png", "image/png" },
                // ... ������ ���� ���������� �� ��������
            };

            // �������� ��� �������� �� �����������
            string contentType;
            if (contentTypes.TryGetValue(extension.ToLower(), out contentType))
            {
                return contentType;
            }
            else
            {
                // �� ������������� - application/octet-stream
                return "application/octet-stream";
            }
        }

        private void SendResponse(string response, NetworkStream stream)
        {
            // ����������� ������� HTTP �� ����� �����
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);

            // ³�������� ����� ����� �볺���
            stream.Write(responseBytes, 0, responseBytes.Length);
            stream.Flush();
        }

        private void StopServer()
        {
            if (server != null)
            {
                server.Stop();
                txtLog.AppendText("������ ��������.\n");
            }
        }
    }
}

