using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Repositories
{
    public interface IAddressQueryRepository
    {
        Task<List<AddressDto>> GetAll(CancellationToken cancellationToken);
        Task<AddressDto?> Get(int id, CancellationToken cancellationToken);
    }
}
