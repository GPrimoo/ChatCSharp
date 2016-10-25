using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Chat_Servidor
{
    class Program
    {
        int count = 0;
        string portas = "";
        string nicks = "";
        string IP = "172.27.42.62";

        public void envusrs()
        {
            string[] pts = portas.Split(';');
            Socket socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint endereco;

            foreach (string prt in pts)
            {
                if (prt != "")
                {
                    endereco = new IPEndPoint(IPAddress.Parse(prt), 9061);
                    socketenviar.SendTo(Encoding.UTF8.GetBytes("nUsr!=" + nicks), endereco);
                }
            }
            socketenviar.Close();
        }

        public void receber()
        {
            string Mensagem;
            string[] pts = portas.Split(';');
            Socket socketreceber = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            EndPoint endereco = new IPEndPoint(IPAddress.Parse(IP), 9060);
            IPEndPoint endereco2;// = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9061);

            byte[] data = new byte[1024];
            int qtdbytes;

            socketreceber.Bind(endereco);
            while (true)
            { 
                qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
                Mensagem = Encoding.UTF8.GetString(data, 0, qtdbytes);

                if (Mensagem.IndexOf("nEpr!") == 0)
                {
                    string[] aux = Mensagem.Split('=');
                    string[] aux2 = aux[1].Split(':');
                    portas = portas = portas + aux2[0] + ";";
                    nicks = nicks += aux2[1] + ";";
                    count += 1;
                    envusrs();
                }
                else if (Mensagem.IndexOf("nSpr!") == 0)
                {
                    string[] aux = Mensagem.Split('=');
                    string[] aux2 = aux[1].Split(':');
                    portas = portas.Replace(aux2[0], null);
                    nicks = nicks.Replace(aux2[1] + ";", "");
                    count -= 1;
                    envusrs();
                }
                else //if(portas.IndexOf(";") != -1)
                {
                    Socket socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    string[] pt = portas.Split(';');

                    foreach (string prt in pt)
                    {
                        if (prt != "")
                        {
                            endereco2 = new IPEndPoint(IPAddress.Parse(prt), 9061);
                            socketenviar.SendTo(Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data, 0, qtdbytes)), endereco2);
                        }
                    }
                    socketenviar.Close();
                }
            }
        }

        public void Users()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(7, 1);
            Console.Write("╔════════════════════╗");
            Console.SetCursorPosition(7, 2);
            Console.Write("║ Lista de usuários! ║");
            Console.SetCursorPosition(7, 3);
            Console.Write("╚════════════════════╝");
            int i = 5;
            string[] nickss = nicks.Split(';');
            if (nicks.Length == 0)
            {
                Console.SetCursorPosition(7, i);
                Console.Write("Nenhum usuário logado!");
                i += 2;
            }
            else
                foreach (string nick in nickss)
                {
                    Console.SetCursorPosition(9, i);
                    Console.Write(nick);
                    i += 2;
                }
            Console.SetCursorPosition(7, i);
            Console.Write("Aperte em qualquer tecla para voltar!");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            char op;
            Program programa = new Program();
            Thread mythread = new Thread(new ThreadStart(programa.receber));
            int val = 0;

            Console.SetCursorPosition(7, 5);
            Console.Write("Digite o IP do servidor(IP desta máquina): ");
            programa.IP = Console.ReadLine();

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(7, 1);
                Console.Write("Servidor do Chat V1.0");
                Console.SetCursorPosition(6, 4);
                Console.Write("╔═════════════════════════╗");
                Console.SetCursorPosition(6, 5);
                Console.Write("║ Opções:                 ║");
                Console.SetCursorPosition(6, 6);
                Console.Write("║                         ║");
                Console.SetCursorPosition(6, 7);
                if (val == 2)
                    Console.Write("║ [1] Resumir o Servidor  ║");
                else
                    Console.Write("║ [1] Iniciar o Servidor  ║");
                Console.SetCursorPosition(6, 8);
                Console.Write("║ [2] Pausar o Servidor   ║");
                Console.SetCursorPosition(6, 9);
                Console.Write("║ [3] Ver conexões        ║");
                Console.SetCursorPosition(6, 10);
                Console.Write("║ [0] Desligar o servidor ║");
                Console.SetCursorPosition(6, 12);
                Console.Write("║ Escolha a opção: [ ]    ║");
                Console.SetCursorPosition(6, 11);
                Console.Write("║                         ║");
                Console.SetCursorPosition(6, 13);
                Console.Write("╚═════════════════════════╝");
                Console.SetCursorPosition(5, 15);
                Console.Write("Status do servidor:");
                Console.SetCursorPosition(25, 15);
                if (val == 0 || val == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Parado!  ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Iniciado!");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(26, 12);
                op = Console.ReadKey().KeyChar;

                switch (op)
                {
                    case '1':
                        if (val == 0 || val == 2)
                        {
                            if (val == 2)
                                mythread.Resume();
                            else
                                mythread.Start();
                            //Console.WriteLine("\n\nIniciando o Servidor...");
                            val = 1;
                        }
                        else
                            Console.WriteLine("\n\nServidor já iniciado!");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case '2':
                        if (val == 1)
                        {
                            mythread.Suspend();
                            //Console.WriteLine("\n\nParando o Servidor...");
                            val = 2;
                        }
                        else
                            Console.WriteLine("\n\nServido não iniciado!");
                        
                        break;
                    case '3':
                        programa.Users();
                        break;
                    case '0':
                        mythread.Abort();
                        Console.SetCursorPosition(25, 15);
                        Console.WriteLine("Desligando...");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    default:
                        break;
                }
            } while (op != '0');
            Environment.Exit(0);
        }
    }
}
