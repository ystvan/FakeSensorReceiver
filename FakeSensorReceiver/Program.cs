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
            UdpClient simpleSocket = new UdpClient(7000);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Broadcast, 7000);

            //Go to an infinite loop

            while (true)
            {
                Byte[] databuffer = new byte[4000];

                databuffer = simpleSocket.Receive(ref RemoteIpEndPoint);

                String text = Encoding.ASCII.GetString(databuffer);



                string[] data = text.Split('\n');
                //string clientName = data[0];
                //string text1 = data[1] + data[2];

                int light;
                int temp;
                String timestamp;

                //TextReader tr = new StringReader(text);
                //String str1 = tr.ReadLine();
                //String str2 = tr.ReadLine();
                //String str3 = tr.ReadLine();

                light = Convert.ToInt32(data[1].Split(' ')[1]);
                temp = Convert.ToInt32(data[2].Split(' ')[1]);

                timestamp = data[0].Split(' ')[1];

                Console.WriteLine("The current time is: {0} \n The ligh sensor shows {1} LUMEN and \n\tthe temperature is {2} \n\t Fahrenheit \n\n", timestamp, light, temp);




            }
        }
    }
}
