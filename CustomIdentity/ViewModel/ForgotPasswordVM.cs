using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModel
{
    public class ForgotPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
