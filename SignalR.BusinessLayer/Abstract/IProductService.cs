using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductWithCategories();
        int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductAveragePrice();
        decimal TProductMaxPrice();
        decimal TProductMinPrice();
        decimal TProductAveragePriceByCategoryNameHamburger();
    }
}