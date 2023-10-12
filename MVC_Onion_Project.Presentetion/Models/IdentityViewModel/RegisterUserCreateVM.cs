using System.ComponentModel.DataAnnotations;

namespace MVC_Onion_Project.Presentation.Models.IdentityViewModel
{
    public class RegisterUserCreateVM
    {
        // Sign Up (Kaydolma) işlemi için kullanılacak alanlar
        [Required]
        [EmailAddress]
        public string RegisterEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }

        [Compare("RegisterPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }



    }

}
