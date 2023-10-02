using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.Models;
using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public Product Product { get; set; }
        public ProductRepository(ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }
        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
