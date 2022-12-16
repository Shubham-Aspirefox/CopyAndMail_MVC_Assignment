using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CopyAndMail
{
    public class MailSeding
    {
        IOperations operations = new OperationClass();
        public void SendMailUsingMultithreading()
        {
            Task task1 = Task.Factory.StartNew(() => operations.SendMail("jiteshk.aspirefox@gmail.com"));
            Task task2 = Task.Factory.StartNew(() => operations.SendMail("singhshubham7306@gmail.com"));
            Task task3 = Task.Factory.StartNew(() => operations.SendMail("rohitk.aspirefox@gmail.com"));
            Task task4 = Task.Factory.StartNew(() => operations.SendMail("sshubu202@gmail.com"));
            Task.WaitAll(task1, task2, task3, task4);

            Console.WriteLine("All mail send");
            Console.WriteLine("Have a Nice Day");
            Console.ReadLine();
        }

    }
}
