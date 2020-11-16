﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            dataTable.Columns.Add("ContactType", typeof(string));
            dataTable.Columns.Add("BookName", typeof(string));

            dataTable.Rows.Add("Aayush", "Arya", "Street xyz", "New Delhi", "Delhi", "110000", "9999999999", "aayush@gmail.com", "friends", "Capg");
            dataTable.Rows.Add("Aayus", "Arya", "Street xyzww", "New Delhi", "Delhi", "110001", "9999999998", "aayus@gmail.com","profession","Bridgelabz");
            dataTable.Rows.Add("Aayu", "Arya", "Street xyzqq", "Navi Mumbai", "Mumbai", "210000", "9999999988", "aayu@gmail.com", "family", "Capg");
            dataTable.Rows.Add("Aayush", "Ary", "Street abcxyz", "Pilani", "Rajasthan", "310000", "8999999999", "aayush1@gmail.com", "profession", "Bridgelabz");
            dataTable.Rows.Add("Aay", "Arya", "Street xyzop", "New Delhi", "Delhi", "110004", "8899999999", "aay@gmail.com", "friend", "Bridgelabz");
        }


        public void InsertContacts(Contact contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City, contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email, contact.ContactType, contact.BookName);
            Console.WriteLine("Contact inserted successfully");
        }

        public void DisplayAddressBook()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipcode, string phoneNumber, string email, string contactType, string bookName)
        {
            var recordedData = dataTable.AsEnumerable().Where(x => x.Field<string>("FirstName") == firstName).FirstOrDefault();
            if (recordedData != null)
            {
                recordedData.SetField("LastName", lastName);
                recordedData.SetField("Address", address);
                recordedData.SetField("City", city);
                recordedData.SetField("State", state);
                recordedData.SetField("ZipCode", zipcode);
                recordedData.SetField("EmailID", email);
                recordedData.SetField("PhoneNumber", phoneNumber);
                recordedData.SetField("ContactType", contactType);
                recordedData.SetField("BookName", bookName);
                Console.WriteLine("Contact edited successfully");
            }
            else
            {
                Console.WriteLine("No Contact Found");
            }
        }

        public void DeleteContact(string name)
        {
            var deleteRow = dataTable.AsEnumerable().Where(a => a.Field<string>("FirstName").Equals(name)).FirstOrDefault();
            if (deleteRow != null)
            {
                deleteRow.Delete();
                Console.WriteLine("Contact deleted successfully");
            }
        }

        public void RetrieveContactsByCity(string city)
        {
            var cityResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("City") == city);
            foreach (DataRow row in cityResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void RetrieveContactsByState(string state)
        {
            var stateResults = dataTable.AsEnumerable().Where(dr => dr.Field<string>("State") == state);
            foreach (DataRow row in stateResults)
            {
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into grp
                                      select new
                                      {
                                          City = grp.Key.City,
                                          State = grp.Key.State,
                                          Count = grp.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "\t" + row.State + "\t" + row.Count);
            }
        }

        public void SortContactsAlphabeticalyForACity(string city)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("city") == city).OrderBy(x => x.Field<string>("FirstName")).ThenBy(x => x.Field<string>("LastName"));
            foreach (DataRow row in records)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    Console.Write(row[column] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void CountContactsByContactType()
        {
            var records = dataTable.AsEnumerable().GroupBy(x => x.Field<string>("ContactType")).Select(x => new { ContactType = x.Key, Count = x.Count() });
            foreach (var row in records)
            {
                Console.WriteLine(row.ContactType + "\t" + row.Count);
            }
        }

    }
}