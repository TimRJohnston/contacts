using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using AngularPhonebookApp.Models;
using AngularPhonebookApp.Services;

namespace AngularPhonebookApp.Controllers
{
    
    public class ContactController : Controller
    {
        ContactService contactService = new ContactService();
        [HttpGet]
        [Route("api/Contact/Index")]
        public IEnumerable<Contact> Index()
        {
            return contactService.GetAllContacts();
        }
        [HttpPost]
        [Route("api/Contact/Create")]
        public int Create([FromBody] Contact contact)
        {
            return contactService.AddContact(contact);
        }
        [HttpGet]
        [Route("api/Contact/Details/{id}")]
        public Contact Details(int id)
        {
            return contactService.GetContactData(id);
        }
        [HttpPut]
        [Route("api/Contact/Edit")]
        public int Edit([FromBody]Contact contact)
        {
            return contactService.UpdateContact(contact);
        }
        [HttpDelete]
        [Route("api/Contact/Delete/{id}")]
        public int Delete(int id)
        {
            return contactService.DeleteContact(id);
        }
    }
}
