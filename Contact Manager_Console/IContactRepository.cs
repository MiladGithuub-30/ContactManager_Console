using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager_Console
{
    internal interface IContactRepository
    {
        bool Add(Contact contact);
        bool Edit(string name, string newname, long phonenumber);
        bool Remove(string name, long phone);
        bool RemoveByIndex(int index);
        Contact? Find(string name);


        List<Contact> List();

        void Save();
        void ClearList();
        void Load();
        int Count();
    }
}
