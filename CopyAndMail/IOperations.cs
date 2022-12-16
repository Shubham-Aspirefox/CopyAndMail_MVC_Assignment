using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyAndMail
{
    public interface IOperations
    {
        public Task<string> GetDataAsync(string URL);
        public void WriteToFile(List<User> users, string fileNameWithExtension);

        public void SendMail(string email);
    }
}
