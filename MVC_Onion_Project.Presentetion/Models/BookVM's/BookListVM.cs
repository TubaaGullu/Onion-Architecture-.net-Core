using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Onion_Project.Presentation.Models.BookVM_s
{
    public class BookListVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
     
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }

    }
}
