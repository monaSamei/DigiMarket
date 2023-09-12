using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Dtos;
using App.Domain.Core.Seller.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Seller
{
    public class BidQueryRepository:IBidQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public BidQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BidDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Bids.Select(x => new BidDto()
            {
                Id = id,
               CustomerId= x.CustomerId,
               EndAt=x.EndAt,
               StartAt=x.StartAt,
               FactorId=x.FactorId,
               SellerComment=x.SellerComment,
              SellerId=x.SellerId,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
            }
           ).FirstOrDefaultAsync(x=>x.Id==id,cancellationToken);
            return entity;
        
    }

        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Bids.Select(x => new BidDto()
            {
                Id =x.Id,
                CustomerId = x.CustomerId,
                EndAt = x.EndAt,
                StartAt = x.StartAt,
                FactorId = x.FactorId,
                SellerComment = x.SellerComment,
                SellerId = x.SellerId,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
            }
        ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
