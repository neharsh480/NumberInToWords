using NameNumber.WebAPI.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameNumber.Business.Implementation
{
    public class NameNumberDA
    {
        private Response response;
        public NameNumberDA()
        {
            response = new Response();
        }
        public Task<Response> GetNameAndNumberInWords(string name, decimal number)
        {

            try
            {
                string decimals = "";
                string input = Math.Round(number, 2).ToString();
                if (input.Contains("."))
                {
                    decimals = input.Substring(input.IndexOf(".") + 1);

                    input = input.Remove(input.IndexOf("."));
                }
                string outputStr = GetWords(input) + " Dollars";
                if (decimals.Length > 0)
                {

                    outputStr += " and " + GetWords(decimals) + " Cents";
                }
                response.Data = name + "   " + outputStr;
                response.IsSuccessStatus = true;
            }
            catch (Exception e)
            {
                response.ErrorMessages = response.ErrorMessages;
            }
            return Task.FromResult(response);
        }

        private string GetWords(string input)
        {
            string[] seperators = { "", " Thousand ", " Million ", " Billion " };
            int i = 0;
            string outputStr = "";
            while (input.Length > 0)
            {
                string _3digits = input.Length < 3 ? input : input.Substring(input.Length - 3);
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);
                int no = int.Parse(_3digits);
                _3digits = GetWord(no);
                _3digits += seperators[i];
                outputStr = _3digits + outputStr;
                i++;
            }
            return outputStr;
        }


        private string GetWord(int no)
        {
            string[] Ones =
            {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",
            "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Ninteen"
            };
            string[] Tens = { "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty" };
            string word = "";
            if (no > 99 && no < 1000)
            {
                int i = no / 100;
                word = word + Ones[i - 1] + " Hundred ";
                no = no % 100;
            }
            if (no > 19 && no < 100)
            {
                int i = no / 10;
                word = word + Tens[i - 1] + "-";
                no = no % 10;
            }
            if (no > 0 && no < 20)
            {
                word = word + Ones[no - 1];
            }
            return word;
        }
    }
}
