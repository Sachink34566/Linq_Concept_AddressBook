using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static Linq_concept_Address_book.CustomException;
using Linq_concept_Address_book;

namespace Linq_concept_Address_book
{
    public class AddDetails
    {
        public static void AddDetail(List<Contacts> list)
        {
            try
            {
                Validation validation = new Validation();

                Console.WriteLine("Enter your first name");
                string firstname = Console.ReadLine();
                if (!validation.IsName(firstname)) throw new InvalidNameException();

                Console.WriteLine("Enter your last name");
                string lastname = Console.ReadLine();
                if (!validation.IsName(lastname)) throw new InvalidNameException();

                if (SearchContact.DoesExist(list, firstname, lastname)) throw new AlreadyExit();

                Console.WriteLine("Enter your address");
                string address = Console.ReadLine();
                if (!validation.IsAddress(address)) throw new InvalidAddressException();

                Console.WriteLine("Enter your city");
                string city = Console.ReadLine();
                if (!validation.IsCity(city)) throw new InvalidCity();

                Console.WriteLine("Enter your email");
                string email = Console.ReadLine();
                if (!validation.IsEmail(email)) throw new InvalidEmail();

                Console.WriteLine("Enter your state");
                string state = Console.ReadLine();
                if (!validation.IsState(state)) throw new InvalidState();

                Console.WriteLine("Enter your zipcode");
                string zip = Console.ReadLine();
                if (!validation.IsZip(zip)) throw new InvalidZip();

                Console.WriteLine("Enter your Phone number");
                string phone = Console.ReadLine();
                if (!validation.IsNumber(phone)) throw new InvalidNumberException();

                Contacts contacts = new Contacts(firstname, lastname, address, city, email, state, zip, phone);
                list.Add(contacts);
                foreach (Contacts item in list)
                {
                    item.Display();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
