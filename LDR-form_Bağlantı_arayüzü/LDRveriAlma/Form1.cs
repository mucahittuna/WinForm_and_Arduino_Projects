using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace LDRveriAlma
{
    public partial class Form1 : Form
    {
        private string data;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;                    //textBox1'i yalnızca okunabilir şekilde ayarla
            string[] ports = SerialPort.GetPortNames();  //Seri portları diziye ekleme
            foreach (string port in ports)
                comboBox1.Items.Add(port);               //Seri portları comboBox1'e ekleme

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived); //DataReceived eventini oluşturma
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadLine();                      //Veriyi al
            this.Invoke(new EventHandler(displayData_event));
        }
       
        private void displayData_event(object sender, EventArgs e)
        {
            

            progressBar1.Value = Convert.ToInt16(data);                          //Gelen değeri ProgressBar'ın değerine eşitle
            textBox1.Text += DateTime.Now.ToString() + "        " + data + "\n"; //Gelen veriyi textBox içine güncel zaman ile ekle
            label2.Text = "Işık Değeri = " + data;                               //Gelen veriyi label'1 e eşitle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                button1.Enabled = false;
                button2.Enabled = true;
            }
            catch (Exception )
            {
                MessageBox.Show("HATA");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            button2.Enabled = false;
            button1.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

    }
}