using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Cantract.Repositories
{
    public interface IBidQueryRepository
    {
        Task<List<BidDto>> GetAll(CancellationToken cancellationToken);
        Task<BidDto?> Get(int id,CancellationToken cancellationToken);
    }
}
