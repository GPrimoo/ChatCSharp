using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Chat_Cliente
{
    public partial class Form1 : Form
    {
        Thread mythread;
        Form2 Apld = new Form2();

        public void receber()
        {
            Socket socketreceber = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint endereco = new IPEndPoint(IPAddress.Parse(Apld.ip), 9061);
            byte[] data = new byte[1024];
            int qtdbytes;

            socketreceber.Bind(endereco);
            while (true)
            {
                qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
                string Mensagem = Encoding.UTF8.GetString(data, 0, qtdbytes);
                if (Mensagem.IndexOf("nUsr!") != -1)
                {
                    string[] aux = Mensagem.Split('=');
                    string[] usrs = aux[1].Split(';');
                    lstUsrs.Invoke((Action)delegate ()
                    {
                        lstUsrs.Items.Clear();
                        foreach (string usr in usrs)
                            lstUsrs.Items.Add(usr);
                    });
                }
                else
                {
                    lstCnvs.Invoke((Action)delegate ()
                    {
                        lstCnvs.Items.Add(Encoding.UTF8.GetString(data, 0, qtdbytes));
                    });
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEnvia_Click(object sender, EventArgs e)
        {
            Socket socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endereco = new IPEndPoint(IPAddress.Parse(Apld.ipserv), 9060);
            socketenviar.SendTo(Encoding.UTF8.GetBytes(Apld.Apelido + ": " + txtMsg.Text), endereco);
            socketenviar.Close();
            txtMsg.Text = "";
            txtMsg.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Apld.ShowDialog();
            if (Apld.Apelido == "1@exit@")
                Environment.Exit(0);
            else
            {
                //MessageBox.Show("Seja bem vindo ao nosso chat " + Apld.Apelido);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                /*EndPoint endereco = new IPEndPoint(IPAddress.Parse(Apld.ipserv), 9061);
                Boolean getout = false;

                while (!getout)
                {
                    try
                    {
                        socket.Bind(endereco);
                        getout = true;
                    }
                    catch
                    {
                        MessageBox.Show("Ocorreu um erro na conexão com o Servidor, tente novamente mais tarde!");
                        Close();
                    }
                }*/
                //MessageBox.Show("OPA ENTREI!");
                IPEndPoint ender = new IPEndPoint(IPAddress.Parse(Apld.ipserv), 9060);

                socket.SendTo(Encoding.UTF8.GetBytes("nEpr!=" + Apld.ip + ":" + Apld.Apelido), ender);
                socket.Close();
                //MessageBox.Show("TO AQUI HEIN!");
                mythread = new Thread(new ThreadStart(this.receber));
                mythread.Start();
                //MessageBox.Show("Seja bem vindo ao nosso chat " + Apld.Apelido);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ender = new IPEndPoint(IPAddress.Parse(Apld.ipserv), 9060);
            socket.SendTo(Encoding.UTF8.GetBytes("nSpr!=" + Apld.ip + ":" + Apld.Apelido), ender);
            socket.Close();
            mythread.Abort();
            Environment.Exit(0);
        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEnvia.PerformClick();
            }
        }
    }
}
