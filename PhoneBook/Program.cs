using System;
using PhoneBook.Interface;
using PhoneBook.Services;

namespace PhoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            IShowPrint PrintShow = new ShowPrinter();
            const string password = "123";
            PrintShow.ShowPrint("Parol kiriting: ");
            string inputPassword = Console.ReadLine();
            
            if (inputPassword != password)
            {
                PrintShow.ShowPrint("Noto'g'ri parol. Chiqish...");
                return;
            }

            IPhoneBookService phoneBookService = new PhoneBookService();
            phoneBookService.LoadContacts();

            while (true)
            {

                PrintShow.ShowPrint("\nTelefon Kitobi:");
                PrintShow.ShowPrint("1. Kontakt qo'shish");
                PrintShow.ShowPrint("2. Kontaktni o'chirish");
                PrintShow.ShowPrint("3. Kontaktni yangilash");
                PrintShow.ShowPrint("4. Kontaktni qidirish");
                PrintShow.ShowPrint("5. Kontaktlarni ko'rish");
                PrintShow.ShowPrint("6. Chiqish");

                Console.Write("Tanlang (1-6): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ism: ");
                        string name = Console.ReadLine();
                        Console.Write("Telefon: ");
                        string phone = Console.ReadLine();
                        phoneBookService.AddContact(name, phone);
                        break;
                    case "2":
                        Console.Write("O'chirish uchun ism: ");
                        name = Console.ReadLine();
                        phoneBookService.DeleteContact(name);
                        break;
                    case "3":
                        Console.Write("Yangilash uchun ism: ");
                        name = Console.ReadLine();
                        Console.Write("Yangi telefon: ");
                        string newPhone = Console.ReadLine();
                        phoneBookService.UpdateContact(name, newPhone);
                        break;
                    case "4":
                        Console.Write("Qidirish uchun ism: ");
                        name = Console.ReadLine();
                        phoneBookService.SearchContact(name);
                        break;
                    case "5":
                        phoneBookService.ListContacts();
                        break;
                    case "6":
                        phoneBookService.SaveContacts();
                        return;
                    default:
                        PrintShow.ShowPrint("Noto'g'ri tanlov, qayta urinib ko'ring.");
                        break;
                }
            }
        }
    }
}
