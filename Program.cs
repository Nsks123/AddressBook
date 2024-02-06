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
        public string firstname;
        public string lastname;
        public long phonenumber;
        public string email;
    }
    class AddressBook : Contact
    {
        public long zipcode;
        public string address;
        public string cityname;
        public string state;

        public void add_details()
        {
            Console.Write("Enter First Name: ");
            this.firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            this.lastname = Console.ReadLine();

            Console.Write("Enter Address: ");
            this.address = Console.ReadLine();

            Console.Write("Enter City: ");
            this.cityname = Console.ReadLine();

            Console.Write("Enter State: ");
            this.state = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            this.phonenumber = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Zip Code: ");
            this.zipcode = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter Email: ");
            this.email = Console.ReadLine();
        }

        public void display()
        {
            Console.WriteLine();
            Console.WriteLine("First Name :" + this.firstname);
            Console.WriteLine("Last Name :" + this.lastname);
            Console.WriteLine("Phone Number :" + this.phonenumber);
            Console.WriteLine("Email :" + this.email);
            Console.WriteLine("Address :" + this.address);
            Console.WriteLine("City :" + this.cityname);
            Console.WriteLine("State :" + this.state);
            Console.WriteLine("ZipCode :" + this.zipcode);
        }

        public void edit_contact(List<AddressBook> contact, string name)
        {
            int flag = 0;
            int found = 0;

            for (int i = 0; i < contact.Count; i++)
            {
                if (contact[i].firstname == name)
                {
                    found = 1;
                    contact[i].display();
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
                                contact[i].firstname = Console.ReadLine();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter the new last name : ");
                                contact[i].lastname = Console.ReadLine();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Enter the new phone number : ");
                                contact[i].phonenumber = Convert.ToInt64(Console.ReadLine());
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Enter the new email : ");
                                contact[i].email = Console.ReadLine();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Enter the new address : ");
                                contact[i].address = Console.ReadLine();
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Enter the new city : ");
                                contact[i].cityname = Console.ReadLine();
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Enter the new state : ");
                                contact[i].state = Console.ReadLine();
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Enter the new zipCode : ");
                                contact[i].zipcode = Convert.ToInt32(Console.ReadLine());
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
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program.");
            List<AddressBook> list = new List<AddressBook>();
            AddressBook obj = new AddressBook();
            int flag = 0;
            do
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1.Add Details\n2.Display Details\n3.Edit a contact\n4.Exit");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add details:\n");
                        obj.add_details();
                        list.Add(obj);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Display Details\n");
                        for (int i = 0; i < list.Count; i++)
                        {
                            list[i].display();
                            Console.WriteLine();
                        }
                        Thread.Sleep(2000);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter name to edit the details\n");
                        string name = Console.ReadLine();
                        obj.edit_contact(list, name);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Exited");
                        flag = 1;
                        break;
                }
                Console.Clear();
            } while (flag == 0);
            Console.ReadLine();
        }
    }
}