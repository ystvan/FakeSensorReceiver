using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FakeSensorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "UDP CLIENT";
            Start();
        }

        static void Start()
        {

            // Listening to a port (port number must be identical to server)
            UdpClient simpleSocket = new UdpClient(7080);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            //Go to an infinite loop

            while (true)
            {
                Byte[] databuffer = new byte[4000];

                databuffer = simpleSocket.Receive(ref RemoteIpEndPoint);

                String text = Encoding.ASCII.GetString(databuffer);

                string[] data = text.Split(' ');
                string clientName = data[0];
                string text1 = data[1] + data[2];

                int light;
                int temp;
                String timestamp;

                TextReader tr = new StringReader(text);
                String str1 = tr.ReadLine();
                String str2 = tr.ReadLine();
                String str3 = tr.ReadLine();

                light = Convert.ToInt32(str1.Split(' ')[1]);
                temp = Convert.ToInt32(str2.Split(' ')[1]);

                timestamp = str3.Split(' ')[1];

                Console.WriteLine(text);


            }
        }
    }
}
