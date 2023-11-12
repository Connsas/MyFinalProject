using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        List<Product> IProductService.GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        List<Product> IProductService.GetByUnitPrice(decimal unitMin, decimal unitMax)
        {
            return _productDal.GetAll(p => p.UnitPrice <= unitMax && p.UnitPrice >= unitMin);
        }
    }
}
