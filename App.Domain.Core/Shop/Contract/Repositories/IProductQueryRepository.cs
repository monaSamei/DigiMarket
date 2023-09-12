using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface IProductQueryRepository
    {
        Task<ProductDto?> Get(int id,CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
    }
}
