using System.ComponentModel.DataAnnotations;

namespace MVC_Onion_Project.Presentation.Models.AuthorVM_s
{
    public class AuthorCreateVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.Date)]
		public DateTime DateofBirth { get; set; }

	}
}
