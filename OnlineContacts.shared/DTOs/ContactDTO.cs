using OnlineContacts.shared.Resources;
using System.ComponentModel.DataAnnotations;
namespace OnlineContacts.shared.DTOs
{
  public  class ContactDTO : BaseDto
    {

        public int Id { get; set; } = 0;
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Name))]
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Phone))]
        [Required(ErrorMessage = "*")]
       [StringLength(maximumLength:12, ErrorMessageResourceType =typeof(OnlineContactsResources), ErrorMessageResourceName =nameof(OnlineContactsResources.PhoneLen))]
        public string Phone { get; set; }

        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Address))]
        public string Address { get; set; }
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Notes))]
        public string Notes { get; set; }
    }
}
