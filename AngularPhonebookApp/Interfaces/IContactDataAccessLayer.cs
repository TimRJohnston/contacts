using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularPhonebookApp.Models;
using AngularPhonebookApp.Models.Entity;

namespace AngularPhonebookApp.Interfaces
{
    public interface IContactDataAccessLayer
    {
        IEnumerable<Contact> GetAllContacts();

        int AddContact(Contact contact);

        Contact GetContactData(int id);

        int UpdateContact(Contact contact);

        int DeleteContact(int id);

    }
}
