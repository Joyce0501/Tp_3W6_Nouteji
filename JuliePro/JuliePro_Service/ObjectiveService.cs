using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_Service
{
    public class ObjectiveService :IObjectiveService
    {
        private ModelStateDictionary _modelState;
        private readonly IUnitOfWork _unitOfWork;

        public ObjectiveService()
        public IEnumerable<Product> ListProducts()
        {
            return _entities.ProductSet.ToList();
        }

        public bool CreateProduct(Product productToCreate)
        {
            try
            {
                _entities.AddToProductSet(productToCreate);
                _entities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }

    public interface IObjectiveService
    {
        bool CreateProduct(Product productToCreate);
        IEnumerable<Product> ListProducts();
    }

}
