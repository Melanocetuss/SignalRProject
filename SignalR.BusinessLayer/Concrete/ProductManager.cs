using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> TGetProductWithCategories()
        {
            return _productDal.GetProductWithCategories();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public int TProductCountByCategoryNameHamburger()
        {
            return _productDal.ProductCountByCategoryNameHamburger();
        }

        public int TProductCountByCategoryNameDrink()
        {
            return _productDal.ProductCountByCategoryNameDrink();
        }

        public decimal TProductAveragePrice()
        {
            return _productDal.ProductAveragePrice();
        }

        public decimal TProductMaxPrice()
        {
            return _productDal.ProductMaxPrice();
        }

        public decimal TProductMinPrice()
        {
            return _productDal.ProductMinPrice();
        }

        public decimal TProductAveragePriceByCategoryNameHamburger()
        {
            return _productDal.ProductAveragePriceByCategoryNameHamburger();
        }
    }
}