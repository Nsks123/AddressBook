using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        List<Contact> contacts = new List<Contact>();
        Dictionary<string, Contact> dict = new Dictionary<string, Contact>();
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
            string email_pattern = "^[a-zA-Z0-9]+[@][a-z]+[.][a-z]{1,3}$";
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
            dict.Add(first_name, newcon);
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
        public void searchByCity()
        {
            Console.WriteLine("Enter the city name to get contact :");
            string city_name = Console.ReadLine();
            int count = 0;
            foreach (var con in contacts)
            {
                if (con.City == city_name)
                {
                    displayoneContact(con);
                    count++;
                }
            }
            Console.WriteLine($"count:{count}");
        }
        public void searchByName()
        {
            Console.WriteLine("Enter the name to get city and state :");
            string name = Console.ReadLine();
            foreach (var con in contacts)
            {
                string full_name = con.Fname + con.lastname;
                if (full_name == name)
                {
                    Console.WriteLine($"city:{con.City}");
                    Console.WriteLine($"state:{con.State}");
                }
            }
        }
        public void SortContact()
        {
            foreach (var de in dict)
            {
                displayoneContact(de.Value);
            }
        }
        public List<Contact> all()
        {
            return contacts;
        }
    }
}