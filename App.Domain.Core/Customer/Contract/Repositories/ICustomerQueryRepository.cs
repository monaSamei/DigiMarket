using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Repositories
{
    public interface ICustomerQueryRepository
    {
        Task<CustomerDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken);
    }
}
