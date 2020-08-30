using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientServerCommApp
{
    public partial class SRFiles : Form
    {
        private static string shortFileName = "";
        private static string fileName = "";

        public delegate void FileRecievedEventHandler(object source, string fileName);
        public event FileRecievedEventHandler NewFileRecieved;

        public SRFiles()
        {
            InitializeComponent();

            listen.Visible = false;

            IP.Text = MainForm.persistant_ip;
            Port.Text = MainForm.persistant_port;

            int port = int.Parse(Port.Text);
            Task.Factory.StartNew(() => HandleIncomingFile(port));
            //MessageBox.Show("Listening on port " + port);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "File Sharing Center";
            dlg.ShowDialog();
            txtFile.Text = dlg.FileName;
            fileName = dlg.FileName;
            shortFileName = dlg.SafeFileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ipAddress = IP.Text;
            int port = int.Parse(Port.Text);
            string fileName = txtFile.Text;
            Task.Factory.StartNew(() => SendFile(ipAddress, port, fileName, shortFileName));
            MessageBox.Show("File Sent");
        }

        public void SendFile(string remoteHostIP, int remoteHostPort, string longFileName, string shortFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(remoteHostIP))
                {
                    byte[] fileNameByte = Encoding.ASCII.GetBytes(shortFileName);
                    byte[] fileData = File.ReadAllBytes(longFileName);
                    byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                    byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
                    fileNameLen.CopyTo(clientData, 0);
                    fileNameByte.CopyTo(clientData, 4); fileData.CopyTo(clientData, 4 + fileNameByte.Length);
                    TcpClient clientSocket = new TcpClient(remoteHostIP, remoteHostPort);
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Write(clientData, 0, clientData.GetLength(0));
                    networkStream.Close();
                }
            }
            catch
            {
            }
        }

        private void SRFiles_Load(object sender, EventArgs e)
        {
            this.NewFileRecieved += new FileRecievedEventHandler(Form1_NewFileRecieved);
        }

        private void Form1_NewFileRecieved(object sender, string fileName)
        {
            this.BeginInvoke(new Action(delegate ()
            {
                MessageBox.Show("New File Received\n" + fileName);
                System.Diagnostics.Process.Start("explorer", @"e:\");
            }));
        }

        private void listen_Click(object sender, EventArgs e)
        {
            int port = int.Parse(Port.Text);
            Task.Factory.StartNew(() => HandleIncomingFile(port));
            MessageBox.Show("Listening on port " + port);
        }

        public void HandleIncomingFile(int port)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(port);
                tcpListener.Start();
                while (true)
                {
                    Socket handlerSocket = tcpListener.AcceptSocket();
                    if (handlerSocket.Connected)
                    {
                        string fileName = string.Empty;
                        NetworkStream networkStream = new NetworkStream(handlerSocket);
                        int thisRead = 0;
                        int blockSize = 1024;
                        Byte[] dataByte = new Byte[blockSize];
                        lock (this)
                        {
                            string folderPath = @"e:\";
                            int receivedBytesLen = handlerSocket.Receive(dataByte);
                            int fileNameLen = BitConverter.ToInt32(dataByte, 0);
                            fileName = Encoding.ASCII.GetString(dataByte, 4, fileNameLen);
                            Stream fileStream = File.OpenWrite(folderPath + fileName);
                            fileStream.Write(dataByte, 4 + fileNameLen, (1024 - (4 + fileNameLen)));
                            while (true)
                            {
                                thisRead = networkStream.Read(dataByte, 0, blockSize);
                                fileStream.Write(dataByte, 0, thisRead);
                                if (thisRead == 0)
                                    break;
                            }
                            fileStream.Close();
                        }
                        if (NewFileRecieved != null)
                        {
                            NewFileRecieved(this, fileName);
                        }
                        handlerSocket = null;
                    }
                }
            }
            catch { }
        }

        private void idlelisten_Click(object sender, EventArgs e)
        {
        }
    }
}