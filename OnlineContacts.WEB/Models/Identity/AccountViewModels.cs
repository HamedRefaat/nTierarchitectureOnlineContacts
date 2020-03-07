using OnlineContacts.shared.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineContacts.Models.Identity
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(ResourceType =typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Email))]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Password))]

        public string Password { get; set; }

        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.RememberMe))]

        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Email))]

        public string Email { get; set; }

        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Gender))]

        public string Type { get; set; }

        public string UserId { get; set; }

        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Phone))]

        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.Password))]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(OnlineContactsResources), Name = nameof(OnlineContactsResources.ConfirmPass))]

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class RoleModel
    {
        [Required]
        public string name { get; set; }
        public string id { get; set; }
        public int CountUsers { get; set; }


    }
}
