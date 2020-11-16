using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookLinq
{
    /// <summary>
    /// Contact modal class
    /// </summary>
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string ContactType { get; set; }
        public string BookName { get; set; }

        public Contact() { }
        public Contact(string FirstName, string LastName, string Address, string City, string State, string ZipCode, string PhoneNumber, string Email, string ContactType, string BookName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.City = City;
            this.State = State;
            this.ZipCode = ZipCode;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.ContactType = ContactType;
            this.BookName = BookName;
        }
    }
}