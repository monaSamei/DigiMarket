using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Dtos;
using App.Domain.Core.Seller.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Seller
{
    public class BidCommandRepository : IBidCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public BidCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(BidDto dto, CancellationToken cancellationToken)
        {
            Bid bid = new Bid()
            {
                Id = dto.Id,
                SellerSugestedPrice = dto.SellerSugestedPrice,
                SellerComment = dto.SellerComment,
                IsAccept = dto.IsAccept,
                StartAt = dto.StartAt,
                EndAt = dto.EndAt,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.Bids.AddAsync(bid);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return bid.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Bids.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            _appDbContext.Bids.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(BidDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Bids.FirstOrDefaultAsync(b => b.Id == dto.Id, cancellationToken);
            entity.SellerSugestedPrice = dto.SellerSugestedPrice;
            entity.SellerComment = dto.SellerComment;
            entity.IsAccept = dto.IsAccept;
            entity.StartAt = dto.StartAt;
            entity.EndAt = dto.EndAt;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
