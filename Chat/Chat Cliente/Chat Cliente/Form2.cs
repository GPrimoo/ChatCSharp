using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Chat_Cliente
{
    public partial class Form2 : Form
    {

        public string Apelido;
        public string ip;
        public string ipserv;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Apelido = "1@exit@";
            string nome = Dns.GetHostName();
            IPAddress[] ip = Dns.GetHostAddresses(nome);
            textBox2.Text = ip[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                if (textBox2.Text != "")
                    if (textBox3.Text != "")
                    {
                        Apelido = textBox1.Text;
                        ip = textBox2.Text;
                        ipserv = textBox3.Text;
                        Hide();
                    }
                    else
                        MessageBox.Show("Digite o IP do Servidor!");
                else
                    MessageBox.Show("Digite o IP de sua máquina!");
            else
                MessageBox.Show("Digite um apelido!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }
    }
}
