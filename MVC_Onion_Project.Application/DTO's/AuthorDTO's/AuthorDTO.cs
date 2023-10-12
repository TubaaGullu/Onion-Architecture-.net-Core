using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.DTO_s.AuthorDTO_s
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
		public DateTime DateofBirth { get; set; }

	}
}
