using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    TcpClient tcpClient = new TcpClient();

        //    byte[] buffer = new byte[1024];
        //    Thread myThread;

        //    var obj = new MyThread(tcpClient,buffer);
        //    tcpClient.Connect(IPAddress.Parse("1.85.36.120"), 12012);
        //    myThread = new Thread(obj.receiveData);
        //    myThread.IsBackground = true;
        //    myThread.Start();
        //    Console.ReadKey();
        //}


        private static byte[] result = new byte[1024];
        static void Main(string[] args)
        {
            //设定服务器IP地址
            IPAddress ip = IPAddress.Parse("1.85.36.120");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 12012)); //配置服务器IP与端口
                Console.WriteLine("连接服务器成功");
            }
            catch
            {
                Console.WriteLine("连接服务器失败，请按回车键退出！");
                return;
            }
            //通过clientSocket接收数据
            int receiveLength = clientSocket.Receive(result);
            Console.WriteLine("接收服务器消息：{0}", Encoding.ASCII.GetString(result, 0, receiveLength));
            //通过 clientSocket 发送数据
           while(true)
            {
                try
                {
                    Thread.Sleep(1000);    //等待1秒钟
                    string sendMessage = "client send Message Hellp" + DateTime.Now;
                    clientSocket.Send(Encoding.ASCII.GetBytes(sendMessage));
                    Console.WriteLine("向服务器发送消息：{0}" + sendMessage);
                }
                catch
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
            Console.WriteLine("发送完毕，按回车键退出");
            Console.ReadLine();
        }



        public class MyThread
        {
            private NetworkStream myNetworkStream;
            private TcpClient tcpClient;
            private byte[] buffer;

            public MyThread(TcpClient tcpClient, byte[] buffer)
            {
                this.tcpClient = tcpClient;
                this.buffer = buffer;
            }

            public void receiveData()
            {
                while (this.tcpClient.Connected)
                {
                    this.myNetworkStream = tcpClient.GetStream();
                    int i = this.myNetworkStream.Read(buffer, 0, 10);
                    byte[] destinationArray = new byte[i];
                    Array.Copy(buffer, destinationArray, i);
                    var info = ("rece     " + string.Join("-", destinationArray.Select(d => d.ToString("X2")).ToArray()));
                    Console.WriteLine(info);
                }
            }
        }

    }
}
