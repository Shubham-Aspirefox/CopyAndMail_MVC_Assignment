using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CopyAndMail
{
    public class MainMenu
    {
        IOperations operations = new OperationClass();                    
        public async Task StartAsync()
        {
            Validation validate = new Validation();
            Console.Clear  ();
            Console.WriteLine("************ Main Menu ************\n");
            Console.WriteLine("Write GET to fetch the data from Github API\n");

            string? isGet = Console.ReadLine().ToLower();

            #region sh
            isGet = validate.CheckGet(isGet);
            #endregion

            if (isGet.Equals("get"))
            {
                try
                {
                    var res = await operations.GetDataAsync("");
                    List<User> users = JsonConvert.DeserializeObject<List<User>>(res);
                    Console.WriteLine($"\nAll User Fetched from the API. Count = {users.Count}\n");
                    Console.WriteLine("Press any key to write the Details in the file");
                    Console.ReadLine();                    
                    await WriteFile(users);
                    Console.Clear();
                    Console.WriteLine("**************** Work on Progress ********** ");
                    Console.WriteLine("\n\n Press Enter to send the files as an attachment to Mail");
                    //TODO: Send Mail
                    #region
                    var sendmail = new MailSeding();
                    sendmail.SendMailUsingMultithreading();
                    #endregion

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

        }

        public async Task WriteFile(List<User> users)
        {
            Validation validate = new Validation();
            Console.Clear();
            Console.WriteLine("************ Main Menu ************\n");


            Console.WriteLine("Enter the name of the Json file");
            string jsonFileName = Console.ReadLine();
            #region sh
            jsonFileName = validate.CheckJson(jsonFileName);
            #endregion

            //Validate jsonFileName and textFileName for !Empty
            Console.WriteLine("Enter the name of the text file");
            string textFileName = Console.ReadLine();

            #region sh
            textFileName = validate.CheckText(textFileName);
            #endregion



            Thread jsonFileCreation = new Thread(() => { 
                operations.WriteToFile(users, $"{jsonFileName}.json"); 
              Console.WriteLine("JsonFileCreation Thread Started"); 
            });
            Thread textFileCreation = new Thread(() => { operations.WriteToFile(users, $"{textFileName}.txt");
              Console.WriteLine("TextFileCreation Thread Started");
            });
            jsonFileCreation.Start();
            textFileCreation.Start();

        }
    }
}
