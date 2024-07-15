
using PhoneBook.Services;

namespace PhoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string password = "123";
            Console.Write("Parol kiriting: ");
            string inputPassword = Console.ReadLine();

            if (inputPassword != password)
            {
                Console.WriteLine("Noto'g'ri parol. Chiqish...");
                return;
            }

            IPhoneBookService phoneBookService = new PhoneBookService();
            phoneBookService.LoadContacts();

            while (true)
            {
                
                Console.WriteLine("\nTelefon Kitobi:");
                Console.WriteLine("1. Kontakt qo'shish");
                Console.WriteLine("2. Kontaktni o'chirish");
                Console.WriteLine("3. Kontaktni yangilash");
                Console.WriteLine("4. Kontaktni qidirish");
                Console.WriteLine("5. Kontaktlarni ko'rish");
                Console.WriteLine("6. Chiqish");

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
                        Console.WriteLine("Noto'g'ri tanlov, qayta urinib ko'ring.");
                        break;
                }
            }
        }
    }
}
