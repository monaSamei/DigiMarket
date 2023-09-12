using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Cantract.Services;
using App.Domain.Core.Seller.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Seller
{
    public class SellerService:ISellerService
    {
        public SellerService(ISellerCommandRepository commandRepository,ISellerQueryRepository queryRepository) { }

        public Task<int> Add(SellerDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SellerDto?> Get(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(SellerDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
