﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;
        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductWithCategories()
        {                     
            return _context.Products.Include(x => x.Category).ToList();
        }
       
        public int ProductCount()
        {           
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _context.Products
                .Include(x => x.Category)
                .Where(x => x.Category.Name == "İçecek").Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _context.Products
                .Include(x => x.Category)
                .Where(x => x.Category.Name == "Hamburger").Count();
        }

        public decimal ProductAveragePrice()
        {
            return _context.Products.Average(x => x.Price);
        }
        
        public string ProductNameMaxPrice()
        {
            return _context.Products
                .OrderByDescending(x => x.Price)
                .Select(x => x.Name)
                .FirstOrDefault() ?? "No products available"; ;
        }

        public string ProductNameMinPrice()
        {
            return _context.Products
                .OrderBy(x => x.Price)
                .Select(x => x.Name)
                .FirstOrDefault() ?? "No products available"; ;
        }

        public decimal ProductAveragePriceByCategoryNameHamburger()
        {
            return _context.Products
                .Include(x => x.Category)
                .Where(x => x.Category.Name == "Hamburger")
                .Average(x => x.Price);
        }
    }
}