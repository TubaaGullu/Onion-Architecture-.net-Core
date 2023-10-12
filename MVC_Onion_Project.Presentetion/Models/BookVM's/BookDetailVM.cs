using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Onion_Project.Presentation.Models.BookVM_s
{
    public class BookDetailVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        //public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }

		public List<Guid> SelectedCategoryIds { get; set; }
		public SelectList CategoryList { get; set; }

	}
}
