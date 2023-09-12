using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Services
{
    public interface IShopService
    {
        Task<int> Add(ShopDto dto, CancellationToken cancellationToken);
        Task<int> Update(ShopDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<ShopDto>> GetAll(CancellationToken cancellationToken);
        Task<ShopDto?> Get(int id, CancellationToken cancellationToken);
    }
}
