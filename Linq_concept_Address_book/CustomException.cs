using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_concept_Address_book
{
    public class CustomException : ApplicationException
    {
        public CustomException(string message) : base(message)
        {
        }

        public class InvalidNameException : CustomException
        {
            public InvalidNameException() : base("Please enter a correct name")
            {
            }
        }

        public class InvalidAddressException : CustomException
        {
            public InvalidAddressException() : base("Enter a valid address")
            {
            }
        }

        public class InvalidNumberException : CustomException
        {
            public InvalidNumberException() : base("The entered number is not in the correct format!")
            {
            }
        }

        public class InvalidZip : CustomException
        {
            public InvalidZip() : base("Enter a correct zip code")
            {
            }
        }

        public class InvalidState : CustomException
        {
            public InvalidState() : base("Enter a correct state format")
            {
            }
        }

        public class InvalidCity : CustomException
        {
            public InvalidCity() : base("Enter a correct city name")
            {
            }
        }

        public class InvalidEmail : CustomException
        {
            public InvalidEmail() : base("Enter a correct email")
            {
            }
        }
        public class AlreadyExit : CustomException
        {
            public AlreadyExit() : base("This person already exists in the address book.")
            {

            }
        }
    }
}
