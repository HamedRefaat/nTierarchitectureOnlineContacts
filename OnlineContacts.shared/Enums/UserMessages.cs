using OnlineContacts.shared.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.shared.Enums
{
    public enum UserMessages
    {
        [Display(ResourceType = typeof(OnlineContactsResources), Name = "AddedSucessMsg")]
        Added,
        [Display(ResourceType = typeof(OnlineContactsResources), Name = "EditSucessMsg")]
        Edited,
        [Display(ResourceType = typeof(OnlineContactsResources), Name = "DeleteSucessMsg")]
        Deleted,
        [Display(ResourceType = typeof(OnlineContactsResources), Name = "ErrorMsg")]
        Error,
        [Display(ResourceType = typeof(OnlineContactsResources), Name = "DeleteConfirmationMsg")]
        ConfirmDelete,


    }
}
