using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface IShopCommandRepository
    {
        Task<int> Add(ShopDto dto, CancellationToken cancellationToken);
        Task<int> Update(ShopDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
