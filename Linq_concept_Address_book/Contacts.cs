using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_concept_Address_book
{
    public class Contacts
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Phonenumber { get; set; }

        public Contacts(string firstname, string lastname, string address, string city, string email, string zip, string state, string phonenumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            City = city;
            Email = email;
            Zip = zip;
            State = state;
            Phonenumber = phonenumber;

        }
        public void Display()
        {
            Console.WriteLine($"{Firstname} {Lastname} {Address} {City} {Email} {Zip} {State} {Phonenumber}");
        }
    }
}
