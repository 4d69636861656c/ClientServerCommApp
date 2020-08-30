using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ClientServerCommApp
{
    public partial class MainForm : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string receive;
        public string text_to_send;

        public static string persistant_ip;
        public static string persistant_port;

        public MainForm()
        {
            InitializeComponent();

            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());  //get my IP Address
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    textBox3.Text = address.ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)  //Start Server
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(textBox4.Text));
            listener.Start();
            client = listener.AcceptTcpClient();
            STR = new StreamReader(client.GetStream());
            STW = new StreamWriter(client.GetStream());
            STW.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
            backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //receive data
        {
            while (client.Connected)
            {
                try
                {
                    receive = STR.ReadLine();
                    this.textBox2.Invoke(new MethodInvoker(delegate ()
                                                                    {
                                                                        textBox2.AppendText("You :: " + receive + "\n");
                                                                    }));
                    receive = "";
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message.ToString());
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e) //send data
        {
            if (client.Connected)
            {
                STW.WriteLine(text_to_send);
                this.textBox2.Invoke(new MethodInvoker(delegate ()
                                                                {
                                                                    textBox2.AppendText("Me :: " + text_to_send + "\n");
                                                                }));
            }
            else
            {
                MessageBox.Show("Send failed!");
            }

            backgroundWorker2.CancelAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(textBox5.Text), int.Parse(textBox6.Text));

            try
            {
                client.Connect(IP_End);
                textBox2.AppendText("Connecting to Server ..." + "\n");
                if (client.Connected)
                {
                    textBox2.AppendText("Connected to Server ..." + "\n");
                    STW = new StreamWriter(client.GetStream());
                    STR = new StreamReader(client.GetStream());
                    STW.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync();                         //start receiving data in background
                    backgroundWorker2.WorkerSupportsCancellation = true;        //ability to cancel this thread
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)  //Send button
        {
            if (textBox1.Text != "")
            {
                text_to_send = textBox1.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(textBox3.Text)) && (!string.IsNullOrWhiteSpace(textBox4.Text)))
            {
                persistant_ip = textBox3.Text;
                persistant_port = textBox4.Text;
                label9.Visible = false;

                SRFiles WSRFiles = new SRFiles();
                WSRFiles.Show();
            }
            else if ((!string.IsNullOrWhiteSpace(textBox5.Text)) && (!string.IsNullOrWhiteSpace(textBox6.Text)))
            {
                persistant_ip = textBox5.Text;
                persistant_port = textBox6.Text;
                label9.Visible = false;

                SRFiles WSRFiles = new SRFiles();
                WSRFiles.Show();
            }
            else
            {
                label9.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Help WHelp = new Help();
            WHelp.Show();
        }

        //  The rest is design-related

        private void Form1_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            button8.Visible = true;
            this.MinimumSize = new System.Drawing.Size(468, 470);
            this.MaximumSize = new System.Drawing.Size(468, 470);
            this.Height = 470;
            this.CenterToScreen();
            this.Refresh();

            button2.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button1.Location = new Point(button1.Location.X, button1.Location.Y - 115);
            button3.Location = new Point(button3.Location.X, button3.Location.Y - 115);
            button4.Location = new Point(button4.Location.X, button4.Location.Y - 115);
            //button6.Location = new Point(button6.Location.X, button6.Location.Y - 115);
            button7.Location = new Point(button7.Location.X, button7.Location.Y - 115);
            label2.Location = new Point(label2.Location.X, label2.Location.Y - 115);
            label4.Location = new Point(label4.Location.X, label4.Location.Y - 115);
            label6.Location = new Point(label6.Location.X, label6.Location.Y - 115);
            label7.Location = new Point(label7.Location.X, label7.Location.Y - 115);
            label8.Location = new Point(label8.Location.X, label8.Location.Y - 115);
            label9.Location = new Point(label9.Location.X, label9.Location.Y - 115);
            textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y - 115);
            textBox2.Location = new Point(textBox2.Location.X, textBox2.Location.Y - 115);
            textBox5.Location = new Point(textBox5.Location.X, textBox5.Location.Y - 115);
            textBox6.Location = new Point(textBox6.Location.X, textBox6.Location.Y - 115);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button8.Visible = true;
            this.MinimumSize = new System.Drawing.Size(468, 470);
            this.MaximumSize = new System.Drawing.Size(468, 470);
            this.Height = 470;
            this.CenterToScreen();
            this.Refresh();

            button2.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label5.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button1.Location = new Point(button1.Location.X, button1.Location.Y - 115);
            button3.Location = new Point(button3.Location.X, button3.Location.Y - 115);
            button4.Location = new Point(button4.Location.X, button4.Location.Y - 115);
            //button6.Location = new Point(button6.Location.X, button6.Location.Y - 115);
            button7.Location = new Point(button7.Location.X, button7.Location.Y - 115);
            label2.Location = new Point(label2.Location.X, label2.Location.Y - 115);
            label4.Location = new Point(label4.Location.X, label4.Location.Y - 115);
            label6.Location = new Point(label6.Location.X, label6.Location.Y - 115);
            label7.Location = new Point(label7.Location.X, label7.Location.Y - 115);
            label8.Location = new Point(label8.Location.X, label8.Location.Y - 115);
            label9.Location = new Point(label9.Location.X, label9.Location.Y - 115);
            textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y - 115);
            textBox2.Location = new Point(textBox2.Location.X, textBox2.Location.Y - 115);
            textBox5.Location = new Point(textBox5.Location.X, textBox5.Location.Y - 115);
            textBox6.Location = new Point(textBox6.Location.X, textBox6.Location.Y - 115);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button5.Visible = true;
            button8.Visible = false;
            this.MinimumSize = new System.Drawing.Size(468, 570);
            this.MaximumSize = new System.Drawing.Size(468, 570);
            this.Height = 570;
            this.CenterToScreen();
            this.Refresh();

            button2.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            label5.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button1.Location = new Point(button1.Location.X, button1.Location.Y + 115);
            button3.Location = new Point(button3.Location.X, button3.Location.Y + 115);
            button4.Location = new Point(button4.Location.X, button4.Location.Y + 115);
            //button6.Location = new Point(button6.Location.X, button6.Location.Y + 115);
            button7.Location = new Point(button7.Location.X, button7.Location.Y + 115);
            label2.Location = new Point(label2.Location.X, label2.Location.Y + 115);
            label4.Location = new Point(label4.Location.X, label4.Location.Y + 115);
            label6.Location = new Point(label6.Location.X, label6.Location.Y + 115);
            label7.Location = new Point(label7.Location.X, label7.Location.Y + 115);
            label8.Location = new Point(label8.Location.X, label8.Location.Y + 115);
            label9.Location = new Point(label9.Location.X, label9.Location.Y + 115);
            textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 115);
            textBox2.Location = new Point(textBox2.Location.X, textBox2.Location.Y + 115);
            textBox5.Location = new Point(textBox5.Location.X, textBox5.Location.Y + 115);
            textBox6.Location = new Point(textBox6.Location.X, textBox6.Location.Y + 115);
        }
    }
}