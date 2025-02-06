using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductWithCategories();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        decimal ProductAveragePrice();
        decimal ProductMaxPrice();
        decimal ProductMinPrice();
        decimal ProductAveragePriceByCategoryNameHamburger();
    }
}