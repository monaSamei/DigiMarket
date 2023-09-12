using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface IShopQueryRepository
    {
        Task<List<ShopDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopDto?> Get(int id, CancellationToken cancellationToken);
    }
}
