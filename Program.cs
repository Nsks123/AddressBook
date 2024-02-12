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
                Console.WriteLine("4.To find the city of the contact person");
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
                        Console.WriteLine("Enter the name of the person's AddressBook: ");
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
                                Console.WriteLine("5 To display contact by city");
                                Console.WriteLine("6.TO Exit from the Address Book");
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
                                    case 5:
                                        Console.Clear();
                                        obj.search();
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
                    case 5:

                        flag = false;
                        break;
                }
            } while (flag);
        }
    }
}