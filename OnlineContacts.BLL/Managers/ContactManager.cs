using OnlineContacts.BLL.Managers.Interfaces;
using OnlineContacts.DAL.Entities;
using OnlineContacts.DAL.Repositories;
using OnlineContacts.DAL.Repositories.Interfaces;
using OnlineContacts.shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.BLL.Managers
{
    public class ContactManager : IContactManager
    {
        private readonly IContactsRepository contactsRepository;

        public ContactManager(IContactsRepository IContactsRepository)
        {
            contactsRepository = IContactsRepository;
        }

        public ContactDTO Add(ContactDTO Model)
        {
            ContactEntity entity = new ContactEntity
            {

                Address = Model.Address,
                Name = Model.Name,
                Notes = Model.Notes,
                Phone = Model.Phone,
            };
            contactsRepository.Add(entity);
            contactsRepository.SaveDbChanges();
            Model.Id = entity.Id;
            return Model;
        }

        public void DeleteById(object Id)
        {
            contactsRepository.DeleteByID(Id);
            contactsRepository.SaveDbChanges();
        }

        public ContactDTO GetById(object Id)
        {
            var entity = contactsRepository.GetById(Id);
            if (entity == null) return null;
            return new ContactDTO()
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                Notes = entity.Notes,
                Phone = entity.Phone,

            };
        }

        public IQueryable<ContactDTO> GetForGrid()
        {
            return contactsRepository.GetForGrid().Select(c => new ContactDTO() {
                Address = c.Address,
                Phone = c.Phone,
                Notes = c.Notes,
                CreatedDate = c.CreatedDate,
                Id = c.Id,
                Name = c.Name,

            });
        }

        public ContactDTO Update(ContactDTO Model)
        {
            var entity = contactsRepository.GetById(Model.Id);
            if (entity == null) return null;
            entity.Name = Model.Name;
            entity.Notes = Model.Notes;
            entity.Phone = Model.Phone;
            entity.Address = Model.Address;
            contactsRepository.Update(entity);
            contactsRepository.SaveDbChanges();
            return Model;
        }
    }
}
