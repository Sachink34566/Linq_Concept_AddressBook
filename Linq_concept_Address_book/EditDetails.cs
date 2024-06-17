
using Linq_concept_Address_book;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Linq_concept_Address_book
{
    public class EditDetails
    {

        public static void EditingContact(List<Contacts> list)
        {
            string oldfirstname, oldlastname;

            Console.WriteLine("Editing the contect details");
            Console.WriteLine("Enter first name");
            string firstname = Console.ReadLine();
            Console.WriteLine("enter last name");
            string lastname = Console.ReadLine();

            if (firstname.Length == 0 || lastname.Length == 0)
            {
                Console.WriteLine("Please enter correct input");
                return;
            }
            else if (firstname.Length > 0 && lastname.Length > 0)
            {

                foreach (Contacts item in list)
                {
                    if (item.Firstname == firstname && item.Lastname == lastname)
                    {
                        oldfirstname = item.Firstname;
                        oldlastname = item.Lastname;
                        while (true)
                        {
                            Console.WriteLine("\nEnter 1 -> edit First Name");
                            Console.WriteLine("Enter 2 -> edit Last Name");
                            Console.WriteLine("Enter 3 -> edit email ");
                            Console.WriteLine("Enter 4 -> edit phone number");
                            Console.WriteLine("Enter 5 -> edit address");
                            Console.WriteLine("Enter 6 -> edit city");
                            Console.WriteLine("Enter 7 -> edit state");
                            Console.WriteLine("Enter 8 -> edit zip code");
                            Console.WriteLine("Enter 9 -> exit editing\n");

                            Console.WriteLine("Enter your choice");
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Edit the first name");
                                    string fname = Console.ReadLine();
                                    item.Firstname = fname;
                                    break;
                                case 2:
                                    Console.WriteLine("Edit last name");
                                    string lname = Console.ReadLine();
                                    item.Lastname = lname;
                                    break;
                                case 3:
                                    Console.WriteLine("Edit email");
                                    string email = Console.ReadLine();
                                    item.Email = email;
                                    break;
                                case 4:
                                    Console.WriteLine("Edit Phone number");
                                    string phonenumber = Console.ReadLine();
                                    item.Phonenumber = phonenumber;
                                    break;
                                case 5:
                                    Console.WriteLine("Edit address");
                                    string address = Console.ReadLine();
                                    item.Address = address;
                                    break;
                                case 6:
                                    Console.WriteLine("Edit city");
                                    string city = Console.ReadLine();
                                    item.City = city;
                                    break;
                                case 7:
                                    Console.WriteLine("Edit state");
                                    string state = Console.ReadLine();
                                    item.State = state;
                                    break;
                                case 8:
                                    Console.WriteLine("Edit zip");
                                    string zip = Console.ReadLine();
                                    item.Zip = zip;
                                    break;
                                case 9:
                                    return;
                                default:
                                    Console.WriteLine("Enter valid input");
                                    break;
                            }

                            item.Display();
                        }
                    }
                    else
                    {
                        Console.WriteLine("enter correct firstname and lastname");
                    }


                }

            }


        }

    }
}