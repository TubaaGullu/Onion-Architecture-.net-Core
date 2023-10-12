using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.DTO_s.BookDTO_s
{
    public class BookListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
