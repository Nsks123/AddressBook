using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            bool flag = true;
            do
            {
                Console.WriteLine("Enter the operation to perform by the user");
                Console.WriteLine("1.To add User ");
                Console.WriteLine("2.To perform operation in the AddressBook");
                Console.WriteLine("3.To display User's of AddressBook");
                Console.WriteLine("4.To exit ");
                int operation = Convert.ToInt16(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter the username");
                        string name = Console.ReadLine();
                        user.add_user(name);
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        int op;
                        Console.Clear();
                        Console.WriteLine("Enter the name of the person: ");
                        string fname = Console.ReadLine();
                        do
                        {
                            if (user.GetPersons().ContainsKey(fname))
                            {
                                AddressBook obj = user.GetAddressBook(fname);
                                Console.WriteLine("Enter the operation to perform");
                                Console.WriteLine("1.To Add the contact in Address_Book");
                                Console.WriteLine("2.To Display the contact in Address Book");
                                Console.WriteLine("3.TO Edit the contact in Address Book");
                                Console.WriteLine("4.TO remove the contact in Address Book");
                                Console.WriteLine("5.TO Exit from the Address Book");
                                op = Convert.ToInt32(Console.ReadLine());
                                switch (op)
                                {
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("Enter the details to add in Address Book");
                                        obj.add_contact();
                                        Console.Clear();
                                        break;
                                    case 2:
                                        Console.Clear();
                                        obj.display();
                                        Thread.Sleep(5000);
                                        Console.Clear();
                                        break;
                                    case 3:
                                        Console.Clear();
                                        obj.edit();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;
                                    case 4:
                                        Console.Clear();
                                        obj.remove();
                                        Thread.Sleep(2000);
                                        Console.Clear();
                                        break;

                                }
                            }
                            else
                            {
                                Console.WriteLine("user is not there in the AddressBook");
                                op = 5;
                                Thread.Sleep(4000);
                                Console.Clear();
                                break;

                            }

                        } while (op != 5);

                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Display the name of AddressBook");
                        user.Display();
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    case 4:

                        flag = false;
                        break;
                }
            } while (flag);
        }
        public class AddressBook
        {

            List<Contact> contacts = new List<Contact>();

            public void add_contact()
            {

                Console.Write("first name: ");
                string firstPattern = "^[a-zA-Z]+$";
                string first_name;
                do
                {
                    first_name = Console.ReadLine();
                    if (!Regex.IsMatch(first_name, firstPattern))
                    {
                        Console.WriteLine("The Entered name is invalid \n Please Enter the valid firstname");
                    }
                } while (!Regex.IsMatch(first_name, firstPattern));
                Console.Write("lastname: ");
                string lastPattern = "^[a-zA-Z]+$";
                string last_name;
                do
                {
                    last_name = Console.ReadLine();
                    if (!Regex.IsMatch(last_name, lastPattern))
                    {
                        Console.WriteLine("The Entered name is invalid \n Please Enter the valid firstname");
                    }
                } while (!Regex.IsMatch(last_name, lastPattern));
                Console.Write("address: ");
                string address = Console.ReadLine();
                Console.Write("city: ");
                string city = Console.ReadLine();
                Console.Write("state: ");
                string state = Console.ReadLine();
                Console.Write("zip: ");
                string zippattern = "^[0-9]{6}$";
                string zip;
                do
                {
                    zip = Console.ReadLine();
                    if (!Regex.IsMatch(zip, zippattern))
                    {
                        Console.WriteLine("This Pincode is not valid \n Enter the valid pincode:");
                    }
                }
                while (!Regex.IsMatch(zip, zippattern));
                Console.Write("email: ");
                string email_pattern = "^[a-zA-z0-9]+[@]+[a-z]+[.]+[a-z]{1,3}$";
                String email;
                do
                {
                    email = Console.ReadLine();
                    if (!Regex.IsMatch(email, email_pattern))
                    {
                        Console.Write("Enter the valid mail id:");
                    }
                } while (!Regex.IsMatch(email, email_pattern));
                Console.Write("Phone number: ");
                string phonePattern = "^[7-9][0-9]{9}$";
                long phone_number;
                string phone;
                do
                {
                    phone_number = Convert.ToInt64(Console.ReadLine());
                    phone = Convert.ToString(phone_number);
                    if (!Regex.IsMatch(phone, phonePattern))
                    {
                        Console.WriteLine("Enter the valid number");
                    }
                } while (!Regex.IsMatch(phone, phonePattern));
                Contact newcon = new Contact(first_name, last_name, address, city, state, zip, phone_number, email);
                contacts.Add(newcon);

            }
            public void display()
            {
                foreach (var con in contacts)
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


            }
            public void edit()
            {
                Console.WriteLine("Enter the mail id of the contact to edit");
                string email = Console.ReadLine();
                string field = "", new_value = "";
                int num = 0;
                int flag = 0;
                foreach (var con in contacts)
                {
                    if (con.Email == email)
                    {
                        flag = 1;
                        Console.WriteLine("Enter the field name you want to edit");
                        field = Console.ReadLine();
                        Console.Write($"Enter the new value of the {field}:");
                        if (field == "number")
                        {
                            num = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            new_value = Console.ReadLine();
                        }
                        switch (field)
                        {
                            case "firstname":
                                con.Fname = new_value;
                                break;
                            case "lastname":
                                con.lastname = new_value;
                                break;
                            case "address":
                                con.Addres = new_value;
                                break;
                            case "city":
                                con.City = new_value;
                                break;
                            case "state":
                                con.State = new_value;
                                break;
                            case "zip":
                                con.ZipCode = new_value;
                                break;
                            case "phone Number":
                                con.PhoneNumber = num;
                                break;
                            case "email":
                                con.Email = new_value;
                                break;
                        }
                    }

                }
                if (flag == 0)
                {
                    Console.WriteLine("Contact is not present in the AddressBook");

                }

            }
            public void remove()
            {
                int flag = 0;
                Console.WriteLine("Enter the mail id of the contact to edit");
                string email = Console.ReadLine();
                foreach (var con in contacts)
                {
                    if (con.Email == email)
                    {
                        flag = 1;
                        contacts.Remove(con);
                        Console.WriteLine("The Contact is removed");
                        break;
                    }

                }
                if (flag == 0)
                {
                    Console.WriteLine("Contact is not there in the addressBook");
                }

            }
        }
        public class Contact
        {
            private string first_name;
            private string last_name;
            private string address;
            private string city;
            private string state;
            private string zip;
            private long phone_number;
            private string email;

            public string Fname
            {
                get { return first_name; }
                set { first_name = value; }
            }
            public string lastname
            {
                get { return last_name; }
                set { last_name = value; }
            }
            public string Addres
            {
                get { return address; }
                set { address = value; }
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
            public string ZipCode
            {
                get { return zip; }
                set { zip = value; }
            }
            public long PhoneNumber
            {
                get { return phone_number; }
                set { phone_number = value; }
            }
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public Contact(string first_name, string last_name, string address, string city, string state, string zip, long phone_number, string email)
            {
                this.first_name = first_name;
                this.last_name = last_name;
                this.address = address;
                this.city = city;
                this.state = state;
                this.zip = zip;
                this.phone_number = phone_number;
                this.email = email;
            }
        }
        public class User
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
}