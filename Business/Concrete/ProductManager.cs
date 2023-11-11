using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager
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
    }
}
