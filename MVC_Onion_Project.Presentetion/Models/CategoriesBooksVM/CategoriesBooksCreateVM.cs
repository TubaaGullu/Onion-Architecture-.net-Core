using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_Onion_Project.Presentation.Models.CategoriesBooksVM
{
    public class CategoriesBooksCreateVM
    {
        public List<Guid> SelectedCategoryIds { get; set; }
        public SelectList CategoryList { get; set; }

    }
}
