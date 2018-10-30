using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using AngularPhonebookApp.Models;

namespace AngularPhonebookApp.Services
{
    public class ContactService
    {

        ContactDataAccessLayer ContactDAL = new ContactDataAccessLayer();

        public IEnumerable<Contact> GetAllContacts()
        {
            return ContactDAL.GetAllContacts();
        }


        public int AddContact(Contact contact)
        {
            return ContactDAL.AddContact(contact);
        }


        public Contact GetContactData(int id)
        {
            return ContactDAL.GetContactData(id);
        }


        public int UpdateContact(Contact contact)
        {
            return ContactDAL.UpdateContact(contact);
        }


        public int DeleteContact(int id)
        {
            return ContactDAL.DeleteContact(id);
        }


    }
}
