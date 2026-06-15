using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Contact_Manager_Console
{
    internal class ContactRepository : IContactRepository
    {
        List<Contact> contacts = new List<Contact>();

        public ContactRepository()
        {
            Load();
        }
        public bool Add(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
                return false;

            contacts.Add(contact);
            Save();
            return true;
        }

        public void ClearList()
        {
            contacts.Clear();
            Save();
        }

        public int Count()
        {
            return contacts.Count;
        }

        public bool Edit(string name, string newname, long phonenumber)
        {
            var contact = contacts.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
                return false;

            contact.Name = newname;
            contact.PhoneNumber = phonenumber;

            Save();
            return true;
        }


        public Contact? Find(string name)
        {
            return contacts.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


        public List<Contact> List()
        {

            return contacts.ToList();
        }

        public void Load()
        {
           if(File.Exists("Contacts.json"))
            {
              string json =  File.ReadAllText("Contacts.json");

                contacts = JsonSerializer.Deserialize<List<Contact>>(json)
                    ?? new List<Contact>();
            }
        }

        public bool Remove(string name, long phoneNumber)
        {
            var contact = contacts.FirstOrDefault(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                c.PhoneNumber == phoneNumber);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            Save();
            return true;
        }

        public bool RemoveByIndex(int index)
        {
            if (index < 1 || index > contacts.Count)
                return false;

            contacts.RemoveAt(index - 1);
            Save();
            return true;
        }



        public void Save()
        {
            string json = JsonSerializer.Serialize(contacts);
            File.WriteAllText("Contacts.json", json);
        }
    }
}
