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
                    showPrint.ShowPrint($"{name} qo'shildi.");
                    
                }
                SaveContacts();
            }
            catch (Exception ex)
            {
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
        }

        private static void ClearMessage()
        {
            Console.ReadKey();
            Console.Clear();
        }

        public void DeleteContact(string name)
        {
            try
            {
                if (contacts.Remove(name))
                {
                    showPrint.ShowPrint($"{name} o'chirildi.");

                }
                else
                {
                    showPrint.ShowPrint($"{name} topilmadi.");
                }
                SaveContacts();
                
            }
            catch (Exception ex)
            {
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
        }

        public void UpdateContact(string name, string newPhone)
        {
            try
            {
                if (contacts.ContainsKey(name))
                {
                    contacts[name] = newPhone;
                    showPrint.ShowPrint($"{name} yangilandi.");
                }
                else
                {
                    showPrint.ShowPrint($"{name} topilmadi.");
                }
                SaveContacts();
            }
            catch (Exception ex)
            {
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
        }

        public void SearchContact(string name)
        {
            try
            {
                if (contacts.ContainsKey(name))
                {
                    showPrint.ShowPrint($"{name}: {contacts[name]}");
                }
                else
                {
                    showPrint.ShowPrint($"{name} topilmadi.");
                }
            }
            catch (Exception ex)
            {
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
        }

        public void ListContacts()
        {
            try
            {
                if (contacts.Count > 0)
                {
                    foreach (var contact in contacts)
                    {
                        showPrint.ShowPrint($"{contact.Key}: {contact.Value}");
                    }
                }
                else
                {
                    showPrint.ShowPrint("Telefon kitobi bo'sh.");
                }
            }
            catch (Exception ex)
            {
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
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
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
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
                showPrint.ShowPrint($"Xatolik: {ex.Message}");
            }
            ClearMessage();
        }
    }
}
