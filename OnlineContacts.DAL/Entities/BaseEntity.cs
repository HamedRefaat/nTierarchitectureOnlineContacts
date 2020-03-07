using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineContacts.DAL.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }

        public string CreatedUser { get; set; }

        public string ModifiedUser { get; set; }


    }
}
