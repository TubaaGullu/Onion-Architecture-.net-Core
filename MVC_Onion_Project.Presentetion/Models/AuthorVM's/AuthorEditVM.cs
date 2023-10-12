using System.ComponentModel.DataAnnotations;

namespace MVC_Onion_Project.Presentation.Models.AuthorVM_s
{
    public class AuthorEditVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }
    }
}
