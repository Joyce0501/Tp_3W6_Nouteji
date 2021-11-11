using JuliePro_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuliePro_DataAccess.Repository.IRepository
{
    public interface ICustomerRepository : IRepositoryAsync<Customer>
    {
        void Update(Customer customer);
    }
}
