using System;
using System.Collections.Generic;
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
        private string phone_number;
        private string city;
        private string state;
        private string zipcode;
        private string address;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Contacts person = new Contacts();
            Console.WriteLine("Welcome to Address Book");
            Console.ReadLine();

        }
    }
}