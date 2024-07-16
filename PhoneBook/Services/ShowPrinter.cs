using PhoneBook.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    internal class ShowPrinter : IShowPrint
    {
        public void ShowPrint(string message) => Console.WriteLine(message);
    }
}
