using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using AngularPhonebookApp.Models;
using AngularPhonebookApp.Interfaces;
using AngularPhonebookApp.Models.Entity;
using AngularPhonebookApp.Models.Mappers;

namespace AngularPhonebookApp.Services
{
    public class ContactService : IContactService
    {

        private IContactDataAccessLayer _contactDAL;
        ContactMapper mapper = new ContactMapper();

        public ContactService(IContactDataAccessLayer contactDAL)
        {
            this._contactDAL = contactDAL;
        }
        
        public IEnumerable<ContactDTO> GetAllContacts()
        {
            IEnumerable<Contact> contacts = _contactDAL.GetAllContacts();
            List<ContactDTO> contactDTOs = new List<ContactDTO>();
            foreach (var contact in contacts)
            {
                contactDTOs.Add(mapper.ToDTO(contact));
            }
            return contactDTOs;
        }

        public int AddContact(ContactDTO contactDto)
        {
            Contact contact = mapper.ToEntity(contactDto);
            contact.SessionID = Guid.NewGuid().ToString();
            return _contactDAL.AddContact(contact);
        }

        public ContactDTO GetContactData(int id)
        {
            ContactDTO contactDTO = mapper.ToDTO(_contactDAL.GetContactData(id));
            return contactDTO;
        }

        public int UpdateContact(ContactDTO contactDto)
        {
            Contact contact = mapper.ToEntity(contactDto);
            contact.SessionID = Guid.NewGuid().ToString();
            return _contactDAL.UpdateContact(contact);
        }

        public int DeleteContact(int id)
        {
            return _contactDAL.DeleteContact(id);
        }
    }
}
