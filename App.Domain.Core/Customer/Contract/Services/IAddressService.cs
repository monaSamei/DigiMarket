using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Services
{
    public interface IAddressService
    {
        Task<int> Add(AddressDto dto, CancellationToken cancellationToken);
        Task<int> Update(AddressDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<AddressDto>> GetAll(CancellationToken cancellationToken);
        Task<AddressDto?> Get(int id, CancellationToken cancellationToken);
    }
}
