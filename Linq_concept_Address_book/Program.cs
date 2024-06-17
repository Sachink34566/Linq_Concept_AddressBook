using Linq_concept_Address_book;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Address_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Multiple Address Book!");
            var addressBooks = new Dictionary<int, MultipleAddressBook>();
            var cities = new Dictionary<string, List<string>>();
            var states = new Dictionary<string, List<string>>();

            int bookIdCounter = 1;

            while (true)
            {
                try
                {
                    Console.WriteLine("\n1. Create Address Book");
                    Console.WriteLine("2. Open Address Book");
                    Console.WriteLine("3. Rename Address Book");
                    Console.WriteLine("4. Display All Address Books");
                    Console.WriteLine("5. Display One Address Book");
                    Console.WriteLine("6. Delete Address Book");
                    Console.WriteLine("7. Display Contacts by City");
                    Console.WriteLine("8. Display Contacts by State");
                    Console.WriteLine("9. Exit\n");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            CreateAddressBook(addressBooks, ref bookIdCounter);
                            break;
                        case 2:
                            OpenAddressBook(addressBooks, cities, states);
                            break;
                        case 3:
                            RenameAddressBook(addressBooks);
                            break;
                        case 4:
                            DisplayAllAddressBooks(addressBooks);
                            break;
                        case 5:
                            DisplayOneAddressBook(addressBooks);
                            break;
                        case 6:
                            DeleteAddressBook(addressBooks);
                            break;
                        case 7:
                            DisplayContactsByCity(cities);
                            break;
                        case 8:
                            DisplayContactsByState(states);
                            break;
                        case 9:
                            return;
                        default:
                            Console.WriteLine("Invalid input, please enter a value between 1 and 9.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Input format error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private static void CreateAddressBook(Dictionary<int, MultipleAddressBook> addressBooks, ref int bookIdCounter)
        {
            Console.Write("Enter the name of the new Address Book: ");
            string bookName = Console.ReadLine();
            var newAddressBook = new MultipleAddressBook(bookIdCounter++, bookName);
            addressBooks[newAddressBook.BookId] = newAddressBook;
            Console.WriteLine($"Address Book '{bookName}' created with ID {newAddressBook.BookId}.");
        }

        private static void OpenAddressBook(Dictionary<int, MultipleAddressBook> addressBooks, Dictionary<string, List<string>> cities, Dictionary<string, List<string>> states)
        {
            Console.WriteLine("Press 1 to open by ID or 2 to open by Name:");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the ID: ");
                int id = int.Parse(Console.ReadLine());
                if (addressBooks.ContainsKey(id))
                {
                    addressBooks[id].Open(cities, states);
                }
                else
                {
                    Console.WriteLine("Address Book ID does not exist.");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the Name: ");
                string name = Console.ReadLine();
                var addressBook = addressBooks.Values.SingleOrDefault(ab => ab.BookName == name);
                if (addressBook != null)
                {
                    addressBook.Open(cities, states);
                }
                else
                {
                    Console.WriteLine("Address Book name does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }

        private static void RenameAddressBook(Dictionary<int, MultipleAddressBook> addressBooks)
        {
            Console.WriteLine("Press 1 to rename by ID or 2 to rename by Name:");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the ID: ");
                int id = int.Parse(Console.ReadLine());
                if (addressBooks.ContainsKey(id))
                {
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();
                    addressBooks[id].BookName = newName;
                    Console.WriteLine("Address Book renamed successfully.");
                }
                else
                {
                    Console.WriteLine("Address Book ID does not exist.");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the current name: ");
                string name = Console.ReadLine();
                var addressBook = addressBooks.Values.SingleOrDefault(ab => ab.BookName == name);
                if (addressBook != null)
                {
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();
                    addressBook.BookName = newName;
                    Console.WriteLine("Address Book renamed successfully.");
                }
                else
                {
                    Console.WriteLine("Address Book name does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }

        private static void DisplayAllAddressBooks(Dictionary<int, MultipleAddressBook> addressBooks)
        {
            Console.WriteLine("All Address Books:");
            foreach (var addressBook in addressBooks.Values)
            {
                Console.WriteLine($"ID: {addressBook.BookId}, Name: {addressBook.BookName}");
            }
        }

        private static void DisplayOneAddressBook(Dictionary<int, MultipleAddressBook> addressBooks)
        {
            Console.WriteLine("Press 1 to display by ID or 2 to display by Name:");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the ID: ");
                int id = int.Parse(Console.ReadLine());
                if (addressBooks.ContainsKey(id))
                {
                    DisplayAddressBookDetails(addressBooks[id]);
                }
                else
                {
                    Console.WriteLine("Address Book ID does not exist.");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the Name: ");
                string name = Console.ReadLine();
                var addressBook = addressBooks.Values.SingleOrDefault(ab => ab.BookName == name);
                if (addressBook != null)
                {
                    DisplayAddressBookDetails(addressBook);
                }
                else
                {
                    Console.WriteLine("Address Book name does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }

        private static void DisplayAddressBookDetails(MultipleAddressBook addressBook)
        {
            Console.WriteLine($"ID: {addressBook.BookId}, Name: {addressBook.BookName}");

            // Using LINQ to sort contacts by Lastname and Firstname
            var sortedContacts = addressBook.list.OrderBy(contact => contact.Lastname).ThenBy(contact => contact.Firstname);

            foreach (var contact in sortedContacts)
            {
                contact.Display();
            }
        }

        private static void DeleteAddressBook(Dictionary<int, MultipleAddressBook> addressBooks)
        {
            Console.WriteLine("Press 1 to delete by ID or 2 to delete by Name:");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the ID: ");
                int id = int.Parse(Console.ReadLine());
                if (addressBooks.ContainsKey(id))
                {
                    addressBooks.Remove(id);
                    Console.WriteLine("Address Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Address Book ID does not exist.");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the Name: ");
                string name = Console.ReadLine();
                var addressBook = addressBooks.Values.SingleOrDefault(ab => ab.BookName == name);
                if (addressBook != null)
                {
                    addressBooks.Remove(addressBook.BookId);
                    Console.WriteLine("Address Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Address Book name does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid option selected.");
            }
        }

        private static void DisplayContactsByCity(Dictionary<string, List<string>> cities)
        {
            Console.WriteLine("Contacts by City:");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key} -> {string.Join(", ", city.Value)}");
            }
        }

        private static void DisplayContactsByState(Dictionary<string, List<string>> states)
        {
            Console.WriteLine("Contacts by State:");
            foreach (var state in states)
            {
                Console.WriteLine($"{state.Key} -> {string.Join(", ", state.Value)}");
            }
        }
    }
}
