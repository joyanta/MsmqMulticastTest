using System;
using System.IO;
using System.Messaging;

namespace MsmqMulticastTest.Subscriber2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var queue = new MessageQueue(".\\private$\\subscriber1"))
            {
                queue.MulticastAddress = "234.1.1.1:8001";
                while (true)
                {
                    var message = queue.Receive();
                    var reader = new StreamReader(message.BodyStream);
                    Console.WriteLine(string.Format("Received: {0}", reader.ReadToEnd()));
                }

            }
        }
    }
}
