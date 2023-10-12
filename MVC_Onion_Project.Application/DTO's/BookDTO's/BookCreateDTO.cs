using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Onion_Project.Application.DTO_s.BookDTO_s
{
    public class BookCreateDTO
    {
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> SelectedCategoryIds { get; set; }
        public SelectList CategoryList { get; set; }
    }
}
