using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AddressBookSystem.Program;

namespace AddressBookSystem
{
    internal class User
    {
        Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();

        public User()
        {
            dict = new Dictionary<string, AddressBook>();
        }
        public void add_user(string name)
        {
            AddressBook book = new AddressBook();
            bool flag = true;
            foreach (var d in dict)
            {
                if (d.Key == name)
                {
                    Console.WriteLine("user Already present ");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                dict.Add(name, book);
                Console.WriteLine("User added successfully in the addressBook");
            }
        }

        public Dictionary<string, AddressBook> GetPersons()
        {
            return dict;
        }
        public void Display()
        {
            foreach (var book in dict)
            {
                Console.WriteLine(book.Key);
            }
        }
        public AddressBook GetAddressBook(string name)
        {
            return dict[name];
        }

    }
}