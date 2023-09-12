using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Cantract.Repositories
{
    public interface ISellerQueryRepository
    {
        Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
        Task<SellerDto?> Get(int id, CancellationToken cancellationToken);
    }
}
