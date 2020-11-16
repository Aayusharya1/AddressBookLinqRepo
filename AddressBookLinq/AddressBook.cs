using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AddressBookLinq
{
    class AddressBook
    {
        DataTable dataTable = new DataTable();
        /// <summary>
        /// DataTable created for storing contact information
        /// </summary>
        public void CreateAddressBook()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(string));
            dataTable.Columns.Add("PhoneNumber", typeof(string));
            dataTable.Columns.Add("EmailID", typeof(string));
        }
        /// <summary>
        /// Insert Contacts in a the addressBook
        /// </summary>
        public void InsertContacts()
        {
            
            dataTable.Rows.Add("Aayush", "Arya", "Street xyz", "New Delhi", "Delhi", "110000", "9999999999", "aayush@gmail.com");
            dataTable.Rows.Add("Aayus", "Arya", "Street xyzww", "New Delhi", "Delhi", "110001", "9999999998", "aayus@gmail.com");
            dataTable.Rows.Add("Aayu", "Arya", "Street xyzqq", "Navi Mumbai", "Mumbai", "210000", "9999999988", "aayu@gmail.com");
            dataTable.Rows.Add("Aayush", "Ary", "Street abcxyz", "Pilani", "Rajasthan", "310000", "8999999999", "aayush1@gmail.com");
            dataTable.Rows.Add("Aay", "Arya", "Street xyzop", "New Delhi", "Delhi", "110004", "8899999999", "aay@gmail.com");
        }

    }
}