using AngularPhonebookApp.Models;
using AngularPhonebookApp.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPhonebookApp.Interfaces
{

    public interface IContactService
    {
        IEnumerable<ContactDTO> GetAllContacts();

        int AddContact(ContactDTO contact);

        ContactDTO GetContactData(int id);

        int UpdateContact(ContactDTO contact);

        int DeleteContact(int id);

    }

}
