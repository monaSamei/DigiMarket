using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Seller.Cantract.Services
{
    public interface ISellerService
    {
        Task<int> Add(SellerDto dto, CancellationToken cancellationToken);
        Task<int> Update(SellerDto dto, CancellationToken cancellationToken); 
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<SellerDto>> GetAll(CancellationToken cancellationToken);
        Task<SellerDto?> Get(int id, CancellationToken cancellationToken);
    }
}
