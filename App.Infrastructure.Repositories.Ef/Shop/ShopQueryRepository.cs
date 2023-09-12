using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class ShopQueryRepository:IShopQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ShopQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ShopDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Shops.Select(x => new ShopDto()
            {
                Id = x.Id,
                SellerId = x.SellerId,
                ShopTitle = x.ShopTitle,
                ShopDescription = x.ShopDescription,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
            ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<ShopDto>> GetAll(CancellationToken cancellationToken)
        {

            var entities = await _appDbContext.Shops.Select(x => new ShopDto()
            {
                Id = x.Id,
                SellerId = x.SellerId,
                ShopTitle = x.ShopTitle,
                ShopDescription = x.ShopDescription,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
            ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
