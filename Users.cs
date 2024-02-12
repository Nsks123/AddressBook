using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AddressBookSystem.Program;

namespace AddressBookSystem
{
    internal class User
    {
        Dictionary<string, AddressBook> dict = new Dictionary<string, AddressBook>();
        List<Contact> co = new List<Contact>();
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
        public void displayoneContact(Contact con)
        {
            Console.WriteLine($"FirstName: {con.Fname}");
            Console.WriteLine($"lastname: {con.lastname}");
            Console.WriteLine($"address: {con.Addres}");
            Console.WriteLine($"city: {con.City}");
            Console.WriteLine($"state: {con.State}");
            Console.WriteLine($"zip: {con.ZipCode}");
            Console.WriteLine($"email: {con.Email}");
            Console.WriteLine($"Phone number: {con.PhoneNumber}");
            Console.WriteLine("----------------------------------------");
        }
        public AddressBook GetAddressBook(string name)
        {
            return dict[name];
        }

        public List<Contact> SearchPersonsInCity(string city)
        {
            List<Contact> results = new List<Contact>();
            foreach (var addressBook in dict.Values)
            {
                results.AddRange(addressBook.SearchByCity(city));
            }
            return results;
        }
        public List<Contact> SearchPersonsInState(string state)
        {
            List<Contact> results = new List<Contact>();
            foreach (var addressBook in dict.Values)
            {
                results.AddRange(addressBook.SearchByState(state));
            }
            return results;
        }
        public List<Contact> SearchPersonsInName(string name)
        {
            List<Contact> results = new List<Contact>();
            foreach (var addressBook in dict.Values)
            {
                results.AddRange(addressBook.SearchByName(name));
            }
            return results;
        }

    }

}