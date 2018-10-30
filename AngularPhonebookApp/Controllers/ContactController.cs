using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using AngularPhonebookApp.Models;
using AngularPhonebookApp.Services;
using AngularPhonebookApp.Interfaces;



namespace AngularPhonebookApp.Controllers
{
    
    public class ContactController : Controller
    {   
        
        ContactService contactService = new ContactService(new ContactDataAccessLayer());
        
        [HttpGet]
        [Route("api/Contact/Index")]
        public IEnumerable<ContactDTO> Index()
        {
            //TODO Add logging
            return contactService.GetAllContacts();
        }
        [HttpPost]
        [Route("api/Contact/Create")]
        public int Create([FromBody] ContactDTO contact)
        {
            return contactService.AddContact(contact);
        }
        [HttpGet]
        [Route("api/Contact/Details/{id}")]
        public ContactDTO Details(int id)
        {
            return contactService.GetContactData(id);
        }
        [HttpPut]
        [Route("api/Contact/Edit")]
        public int Edit([FromBody]ContactDTO contact)
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
