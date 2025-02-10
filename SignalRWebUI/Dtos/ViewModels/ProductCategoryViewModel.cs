using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.ViewModels
{
    public class ProductCategoryViewModel
    {
        public List<ResultProductWithCategoriesDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}