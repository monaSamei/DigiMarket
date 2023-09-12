using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Seller
{
    public class SellerQueryRepository:ISellerQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public SellerQueryRepository(AppDbContext appDbContext) 
        {
        _appDbContext= appDbContext;
        }

        public async Task<SellerDto?> Get(int id, CancellationToken cancellationToken)
        {
           var entity= await _appDbContext.Sellers.Select(x => new SellerDto()
           {
               Id = id,
               AddressId= x.AddressId,
               CreatedAt=x.CreatedAt,
               CreatedBy=x.CreatedBy,
               LastModifiedBy=x.LastModifiedBy,
               LastModifiedAt=x.LastModifiedAt,
           }
           ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Sellers.Select(s=> new SellerDto()
            {
                Id = s.Id,
                AddressId = s.AddressId,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                LastModifiedBy = s.LastModifiedBy,
                LastModifiedAt = s.LastModifiedAt,
            }
            ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
