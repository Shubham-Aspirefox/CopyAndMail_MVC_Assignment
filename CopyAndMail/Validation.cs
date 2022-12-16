using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyAndMail
{
    public class Validation
    {
        #region sh
        public string CheckGet(string isGet)
        {
            string regex = "get";
            Regex re = new Regex(regex);
            if (re.IsMatch(isGet))
            {
                return isGet;
            }
            string fname = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Write GET only to load data : ");
                string tempName = Console.ReadLine();
                if (re.IsMatch(tempName))
                {
                    fname = tempName;
                    flag = false;

                }
            }
            return fname;
        }

        public string CheckJson(string jsonFileName)
        {
            string regex = @"^[a-zA-Z]+[a-zA-Z\s]+$";
            Regex re = new Regex(regex);
            if (re.IsMatch(jsonFileName))
            {
                return jsonFileName;
            }
            string jsonName = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter Json File Name : ");
                string tempNames = Console.ReadLine();
                if (re.IsMatch(tempNames))
                {
                    jsonName = tempNames;
                    flag = false;

                }
            }
            return jsonName;
        }


        public string CheckText(string textFileName)
        {
            string regex = @"^[a-zA-Z]+[a-zA-Z\s]+$";
            Regex re = new Regex(regex);
            if (re.IsMatch(textFileName))
            {
                return textFileName;
            }
            string textFile = "";
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter Text File Name : ");
                string tempNames = Console.ReadLine();
                if (re.IsMatch(tempNames))
                {
                    textFile = tempNames;
                    flag = false;

                }
            }
            return textFile;
        }




        #endregion



    }
}
