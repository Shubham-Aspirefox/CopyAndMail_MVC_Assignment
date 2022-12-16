using Newtonsoft.Json;

namespace CopyAndMail
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            MainMenu mainMenu = new MainMenu();
            await mainMenu.StartAsync();


        }
    }
}