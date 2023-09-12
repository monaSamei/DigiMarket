using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Cantract.Repositories
{
    public interface ISellerCommandRepository
    {
        Task<int> Add(SellerDto dto, CancellationToken cancellationToken);
        Task<int> Update(SellerDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
