using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using ShopEntity = App.Domain.Core.Shop.Entities;
using App.Domain.Core.Shop.Entities;
using App.Infrastructure.SqlServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class ShopCommandRepository:IShopCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ShopCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(ShopDto dto, CancellationToken cancellationToken)
        {
            ShopEntity.Shop shop = new ShopEntity.Shop()
            {
                Id = dto.Id,
               SellerId= dto.SellerId,
               ShopTitle= dto.ShopTitle,
               ShopDescription= dto.ShopDescription,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.Shops.AddAsync(shop);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return shop.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Shops.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            _appDbContext.Shops.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ShopDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Shops.FirstOrDefaultAsync(s => s.Id == dto.Id, cancellationToken);
            entity.SellerId = dto.SellerId;
            entity.ShopTitle = dto.ShopTitle;
            entity.ShopDescription = dto.ShopDescription;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
