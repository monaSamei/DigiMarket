using App.Domain.Core.Customer.Entities;
using App.Domain.Core.Seller.Entities;
using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using App.Domain.Core.Shop.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class FactorCommandRepository : IFactorCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public FactorCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(FactorDto dto, CancellationToken cancellationToken)
        {
            Factor factor = new Factor()
            {
                Id = dto.Id,
                SellerId = dto.SellerId,
                CustomerId = dto.CustomerId,
                IsAccepted = dto.IsAccepted,
                TotalPrice = dto.TotalPrice,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.Factors.AddAsync(factor);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return factor.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Factors.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
            _appDbContext.Factors.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(FactorDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Factors.FirstOrDefaultAsync(f => f.Id == dto.Id, cancellationToken);
            entity.CustomerId = dto.CustomerId;
            entity.SellerId = dto.SellerId;
            entity.CustomerId = dto.CustomerId;
            entity.IsAccepted = dto.IsAccepted;
            entity.TotalPrice = dto.TotalPrice;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
