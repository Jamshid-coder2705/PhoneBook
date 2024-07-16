using PhoneBook.Interface;
using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private IShowPrint showPrint;

        private const string FilePath = "../../../phoneBook.txt";
        private Dictionary<string, string> contacts = new Dictionary<string, string>();

        public PhoneBookService()
        {
            showPrint = new ShowPrinter();
        }

        public void AddContact(string name, string phone)
        {
            try
            {
                if (contacts.ContainsKey(name))
                {
                    showPrint.ShowPrint($"{name} allaqachon mavjud.");
                }
                else
                {
                    contacts[name] = phone;
                    Console.WriteLine($"{name} qo'shildi.");
                    Console.ReadKey();
                    Console.Clear();
                }
                SaveContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void DeleteContact(string name)
        {
            try
            {
                if (contacts.Remove(name))
                {
                    Console.WriteLine($"{name} o'chirildi.");
                }
                else
                {
                    Console.WriteLine($"{name} topilmadi.");
                }
                SaveContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void UpdateContact(string name, string newPhone)
        {
            try
            {
                if (contacts.ContainsKey(name))
                {
                    contacts[name] = newPhone;
                    Console.WriteLine($"{name} yangilandi.");
                }
                else
                {
                    Console.WriteLine($"{name} topilmadi.");
                }
                SaveContacts();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void SearchContact(string name)
        {
            try
            {
                if (contacts.ContainsKey(name))
                {
                    Console.WriteLine($"{name}: {contacts[name]}");
                }
                else
                {
                    Console.WriteLine($"{name} topilmadi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void ListContacts()
        {
            try
            {
                if (contacts.Count > 0)
                {
                    foreach (var contact in contacts)
                    {
                        Console.WriteLine($"{contact.Key}: {contact.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("Telefon kitobi bo'sh.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void LoadContacts()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var lines = File.ReadAllLines(FilePath);
                    contacts = new Dictionary<string, string>();
                    foreach (var line in lines)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            contacts[parts[0]] = parts[1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }

        public void SaveContacts()
        {
            try
            {
                var lines = new List<string>();
                foreach (var contact in contacts)
                {
                    lines.Add($"{contact.Key},{contact.Value}");
                }
                File.WriteAllLines(FilePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xatolik: {ex.Message}");
            }
        }
    }
}
