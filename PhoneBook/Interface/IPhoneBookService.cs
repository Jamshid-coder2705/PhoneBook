

namespace PhoneBook.Services
{
    public interface IPhoneBookService
    {
        void AddContact(string name, string phone);
        void DeleteContact(string name);
        void UpdateContact(string name, string newPhone);
        void SearchContact(string name);
        void ListContacts();
        void LoadContacts();
        void SaveContacts();
    }
}