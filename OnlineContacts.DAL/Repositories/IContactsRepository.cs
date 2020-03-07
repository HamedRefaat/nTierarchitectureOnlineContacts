using OnlineContacts.DAL.Entities;
using OnlineContacts.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.DAL.Repositories
{
  public  class ContactsRepository : BaseRepository<ContactEntity>, IContactsRepository
    {
        public ContactsRepository():base()
        {
            
        }
        public ContactsRepository(OnlienContactContext onlienContactContext): base(onlienContactContext)
        {

        }
    }
}
