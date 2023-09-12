using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Cantract.Repositories
{
    public interface IBidCommandRepository
    {
        Task<int> Add(BidDto dto, CancellationToken cancellationToken);
        Task<int> Update(BidDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
