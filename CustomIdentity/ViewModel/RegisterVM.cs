using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModel
{
    public class RegisterVM
    {
        [Required]
        public string? FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
