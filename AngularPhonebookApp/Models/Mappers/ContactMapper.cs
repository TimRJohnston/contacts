using AngularPhonebookApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularPhonebookApp.Models.Mappers
{
    public class ContactMapper : IEntityMapper<ContactDTO, Contact>
    {


        public Contact ToEntity(ContactDTO dto)
        {
            Contact contact = new Contact();
            contact.ID = dto.ID;
            contact.ContactName = dto.Name;
            contact.Number = dto.Number;

            return contact;
        }

        public ContactDTO ToDTO(Contact entity)
        {
            ContactDTO contactDTO = new ContactDTO();
            contactDTO.ID = entity.ID;
            contactDTO.Name = entity.ContactName;
            contactDTO.Number = entity.Number;

            return contactDTO;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
