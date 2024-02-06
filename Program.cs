using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Contacts
    {
        private string first_name;
        private string last_name;
        private string email;
        private long phone_number;
        private string city;
        private string state;
        private int zipcode;
        private string address;

        public string FirstName
        {
            get { return first_name; }
            set { first_name = value; }
        }
        public string LastName
        {
            get { return last_name; }
            set { last_name = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public long PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public int Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        //Contacts(string first_name, string last_name, string email, long phone_number, string city, string state, int zipcode, string address) {
        //    FirstName= first_name;
        //    LastName= last_name;
        //    Email= email;
        //    PhoneNumber= phone_number;
        //    City= city;
        //    State= state;
        //    Zipcode= zipcode;
        //    Address= address;
        //}

    }
    class AddressBook
    {
        public void addAddressBook()
        {

            Console.WriteLine("Enter_Details: ");
            Console.Write("first_name: ");
            string first_name = Console.ReadLine();
            Console.Write("last_name: ");
            string last_name = Console.ReadLine();
            Console.Write("email: ");
            string email = Console.ReadLine();
            Console.Write("phone_number: ");
            string phone_number = Console.ReadLine();
            Console.Write("city: ");
            string city = Console.ReadLine();
            Console.Write("state: ");
            string state = Console.ReadLine();
            Console.Write("zipcode: ");
            string zipcode = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();


        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook add = new AddressBook();
            add.addAddressBook();
            Console.ReadLine();

        }
    }
}