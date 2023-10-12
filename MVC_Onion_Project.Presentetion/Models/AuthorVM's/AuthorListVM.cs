using System.ComponentModel;

namespace MVC_Onion_Project.Presentation.Models.AuthorVM_s
{
    public class AuthorListVM
    {
        public Guid Id { get; set; }
        [DisplayName("Ad-Soyad")]
        public string FullName { get; set; }
    }
}
