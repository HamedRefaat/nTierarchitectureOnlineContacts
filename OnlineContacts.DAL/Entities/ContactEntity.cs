using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.DAL.Entities
{
   public class ContactEntity :BaseEntity<int>
    {
        [StringLength(maximumLength:50, MinimumLength =2)]
        public string Name { get; set; }
        
        [StringLength(maximumLength: 12, MinimumLength = 2)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

    }
}
