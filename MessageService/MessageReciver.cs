using System;
using System.Messaging;

namespace MessageService
{
    /// <summary>
    /// SMTP service for receving messages.
    /// </summary>
    public class MessageReciver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Latest Message");

            MessageQueue MyQueue;
            MyQueue = new MessageQueue(@".\Private$\MyQueue");

            Message MyMessage = MyQueue.Receive();
            MyMessage.Formatter = new BinaryMessageFormatter();


            Console.WriteLine(MyMessage.Body.ToString());
            Console.ReadLine();
        }
    }
}
