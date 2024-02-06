using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Address_Book_System
{
    class Contact
    {
        private string firstname;
        private string lastname;
        private long phonenumber;
        private string email;
        private long zipcode;
        private string address;
        private string cityname;
        private string state;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public long Phonenumber
        {
            get { return phonenumber; }
            set { phonenumber = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public long Zipcode
        {
            get { return zipcode; }
            set { zipcode = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Cityname
        {
            get { return cityname; }
            set { cityname = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public Contact(string fname, string lname, long pnum, string email, long Zipcode, string addr, string sta, string City)
        {
            this.Firstname = fname;
            this.Lastname = lname;
            this.Phonenumber = pnum;
            this.Email = email;
            this.Zipcode = Zipcode;
            this.Address = addr;
            this.State = sta;
            this.Cityname = City;
        }
    }

    class AddressBook
    {
        List<Contact> contacts = new List<Contact>();

        public void add_details()
        {
            Console.WriteLine("Enter the first name :");
            string fname = Console.ReadLine();

            Console.WriteLine("Enter the last name : ");
            string lname = Console.ReadLine();

            Console.WriteLine("Enter the email : ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the zipCode : ");
            long zipcode = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter the city : ");
            string city = Console.ReadLine();

            Console.WriteLine("Enter the state : ");
            string state = Console.ReadLine();

            Console.WriteLine("Enter the phone number : ");
            long phonenumber = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter the address : ");
            string address = Console.ReadLine();

            Contact newcon = new Contact(fname, lname, phonenumber, email, zipcode, address, state, city);

            contacts.Add(newcon);
        }

        public void display()
        {
            for (int i = 0; i < contacts.Count; i++)
            {

                Console.WriteLine();
                Console.WriteLine("First Name :" + contacts[i].Firstname);
                Console.WriteLine("Last Name :" + contacts[i].Lastname);
                Console.WriteLine("Phone Number :" + contacts[i].Phonenumber);
                Console.WriteLine("Email :" + contacts[i].Email);
                Console.WriteLine("Address :" + contacts[i].Zipcode);
                Console.WriteLine("City :" + contacts[i].Address);
                Console.WriteLine("State :" + contacts[i].Cityname);
                Console.WriteLine("ZipCode :" + contacts[i].State);

            }
        }

        public void edit_contact(string name)
        {
            int flag = 0;
            int found = 0;

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Firstname == name)
                {
                    found = 1;
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine("Select an option");
                        Console.WriteLine("1. First Name\n2. Last Name\n3. Phone Number\n4. Email\n5. Address\n6. City\n7. State\n8. ZipCode\n9. Done\n");
                        int n = Convert.ToInt32(Console.ReadLine());

                        switch (n)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter the new first name :");
                                contacts[i].Firstname = Console.ReadLine();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter the new last name : ");
                                contacts[i].Lastname = Console.ReadLine();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Enter the new phone number : ");
                                contacts[i].Phonenumber = Convert.ToInt64(Console.ReadLine());
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Enter the new email : ");
                                contacts[i].Email = Console.ReadLine();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Enter the new address : ");
                                contacts[i].Address = Console.ReadLine();
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Enter the new city : ");
                                contacts[i].Cityname = Console.ReadLine();
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Enter the new state : ");
                                contacts[i].State = Console.ReadLine();
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Enter the new zipCode : ");
                                contacts[i].Zipcode = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 9:
                                Console.WriteLine("Edited");
                                flag = 1;
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine();
                    } while (flag == 0);
                }
            }
            if (found == 0)
            {
                Console.WriteLine("The given name is not avaiable");
                Thread.Sleep(2000);
            }
        }

        public void delete_contact(string name)
        {
            int flag = 0;

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].Firstname == name)
                {
                    flag = 1;
                    contacts.Remove(contacts[i]);
                    Console.WriteLine("The given contact detail is removed");
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("The given contact detail is not avaiable in address book");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program.");
            AddressBook obj = new AddressBook();
            int flag = 0;
            do
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1.Add Details\n2.Display Details\n3.Edit a contact\n4.Delete\n5.Exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add details:\n");
                        obj.add_details();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Displaying Contact:\n");
                        obj.display();
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter name to edit the details\n");
                        string name = Console.ReadLine();
                        obj.edit_contact(name);
                        Thread.Sleep(2000);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter name to delete a contact\n");
                        name = Console.ReadLine();
                        obj.delete_contact(name);
                        Thread.Sleep(2000);
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Exited");
                        Thread.Sleep(2000);
                        flag = 1;
                        break;
                }
                Console.Clear();
            } while (flag == 0);
            Console.ReadLine();
        }
    }
}