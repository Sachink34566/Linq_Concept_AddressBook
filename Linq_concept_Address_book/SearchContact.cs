
using Linq_concept_Address_book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_concept_Address_book
{ 
    public class SearchContact
    {
        public static bool DoesExist(List<Contacts> list, string firstName, string lastName)
        {
            return list.Any((Contacts) => Contacts.Firstname == firstName && Contacts.Lastname == lastName);
        }
    }
}

