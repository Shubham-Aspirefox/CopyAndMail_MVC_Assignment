using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyAndMail
{
    public class OperationClass : IOperations
    {
        public async Task<string> GetDataAsync(string URL)
        {
            URL = "https://api.github.com/users";


            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "C# program");
                var response = await client.GetAsync(URL);

                return response.Content.ReadAsStringAsync().Result.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"The User Api has following error: {e.Message}");
                throw;
            }
        }


        public void WriteToFile(List<User> users, string fileNameWithExtension)
        {
            // ask for user input of names, pass it in form of list

            string textToWrite = "";
            string path = @"C:\Users\anjit\source\repos\SH_C# Practice work\SH_MVC\CopyAndMail\Attachments\";
            path += $"{fileNameWithExtension}"; //Change to name of the thread
            foreach (var item in users)
            {
                textToWrite += $"The Id of the User is: {item.Id}.\nThe Login Name is: {item.login}.\nThe Profile Url is:{item.url}.\nThe Avatar Url is {item.avatar_url}.\n\n";
            }



            textToWrite += Environment.NewLine;
            if (fileNameWithExtension.Contains(".json"))
            {
                textToWrite = JsonConvert.SerializeObject(users, Formatting.Indented);
                File.WriteAllText(path, textToWrite);

            }
            File.WriteAllText(path, textToWrite);

        }

        public void SendMail(string email)
        {

            Console.WriteLine("Mail sending to :" + email);
            //string Hostmail = "shubhamk.aspirefox@gmail.com";
            //string Email = email;
            //string subject = "Test";
            //string body = "Mail Attached here";
            try
            {
                Attachment attachment;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sshubu202@gmail.com");
                string[] emailId = {  "sshubu202@gmail.com", "singhshubham7306@gmail.com", "rohitk.aspirefox@gmail.com","Jiteshk.aspirefox@gmail.com" };
                foreach (string id in emailId)
                {
                    mail.To.Add(id);
                }
                //mail.To.Add("singhshubham7306@gmail.com");
                mail.Subject = "Subject";
                mail.Body = "You file has been attached";
                attachment = new Attachment(@"C:\Users\anjit\source\repos\SH_C# Practice work\SH_MVC\CopyAndMail\Attachments\shubhamk.json");
                mail.Attachments.Add(attachment);
                using (SmtpClient smtp = new SmtpClient())
                {
                    
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.mailtrap.io";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("c8f1f1c450b6a9", "e2897ccec976ae");
                    //smtp.Send(Hostmail, Email, subject, body);
                    smtp.Send(mail);

                    Console.WriteLine("Mail Sent successfully!!");
                }
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
