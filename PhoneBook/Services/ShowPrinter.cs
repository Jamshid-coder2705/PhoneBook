using PhoneBook.Interface;
using System;

namespace PhoneBook.Services
{
    internal class ShowPrinter : IShowPrint
    {
        public void ShowPrint(string message) => Console.WriteLine(message);
    }
}
