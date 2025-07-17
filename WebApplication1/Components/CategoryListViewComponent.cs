using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Components
{
    public class CategoryListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string? selectedCategory)
        {
            var categories = new List<SelectListItem>{
                new SelectListItem { Text = "Vợt", Value = "Vợt" },
                new SelectListItem { Text = "Bóng", Value = "Bóng" },
                new SelectListItem { Text = "Cầu", Value = "Cầu" },
                new SelectListItem { Text = "Đệm", Value = "Đệm" },
                new SelectListItem { Text = "Quần áo", Value = "Quần áo" }
            };

            foreach (var item in categories)
            {
                if (item.Value == selectedCategory)
                {
                    item.Selected = true;
                    break;
                }
            }

            return View(categories);
        }
    }
}
