using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.ViewModel
{
    public class ProductCategoryViewModel
    {
        public List<ResultProductWithCategoriesDto> Products { get; set; }
        public List<ResultCategoryDto> Categories { get; set; }
    }
}