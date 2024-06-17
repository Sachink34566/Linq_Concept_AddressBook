using Linq_concept_Address_book;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_concept_Address_book
{
    // Starting the project
    public class MultipleAddressBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public List<Contacts> list = new List<Contacts>();

        public MultipleAddressBook(int id, string name)
        {
            BookId = id;
            BookName = name;
        }

        public void Open(Dictionary<string, List<string>> city, Dictionary<string, List<string>> state)
        {
            try
            {
                Console.WriteLine("Welcome to Address Book!\n");

                while (true)
                {
                    Console.WriteLine("\nEnter 1 -> adding person's contact.");
                    Console.WriteLine("Enter 2 -> edit contact via name.");
                    Console.WriteLine("Enter 3 -> delete contact.");
                    Console.WriteLine("Enter 4 -> display contacts.");
                    Console.WriteLine("Enter 5 -> exiting the address book.\n");

                    Console.Write("Enter the choice = ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Adding contact details !");
                            AddDetails.AddDetail(list);

                            // Fetch the last added contact
                            Contacts newContact = list.LastOrDefault();

                            // Update city dictionary
                            if (newContact != null)
                            {
                                city[newContact.City] = city.ContainsKey(newContact.City)
                                    ? city[newContact.City].Concat(new[] { $"{newContact.Firstname} {newContact.Lastname}" }).ToList()
                                    : new List<string> { $"{newContact.Firstname} {newContact.Lastname}" };

                                // Update state dictionary
                                state[newContact.State] = state.ContainsKey(newContact.State)
                                    ? state[newContact.State].Concat(new[] { $"{newContact.Firstname} {newContact.Lastname}" }).ToList()
                                    : new List<string> { $"{newContact.Firstname} {newContact.Lastname}" };

                                newContact.Display();
                            }
                            break;

                        case 2:
                            if (list.Count > 0)
                                EditDetails.EditingContact(list);
                            else
                                Console.WriteLine("Address book is empty! Please add contacts and then edit!");
                            break;

                        case 3:
                            if (list.Count > 0)
                                DeleteDetails.Deletecontact(list);
                            else
                                Console.WriteLine("Address book is empty! Please add contacts and then delete!");
                            break;

                        case 4:
                            if (list.Count > 0)
                            {
                                foreach (Contacts contact in list)
                                {
                                    contact.Display();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Address book is empty! Please add contacts and then display.");
                            }
                            break;

                        case 5:
                            return;

                        default:
                            Console.WriteLine("Invalid input, enter a value between 1 to 5.");
                            break;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
