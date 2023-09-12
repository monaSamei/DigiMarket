using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Services
{
    public interface IProductService
    {
        Task<ProductDto?> Get(int id, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<int> Add(ProductDto dto, CancellationToken cancellationToken);
        Task<int> Update(ProductDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
