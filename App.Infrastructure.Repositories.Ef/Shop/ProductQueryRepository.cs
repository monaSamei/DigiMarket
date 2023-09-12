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
    public class ProductQueryRepository:IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Products.Select(x => new ProductDto()
            {

                Id = x.Id,
                Title = x.Title,
                CategoryId = x.CategoryId,
                IsActive = x.IsActive,
                IsBid = x.IsBid,
                FactorId = x.FactorId,
                ShopId = x.ShopId,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
          ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Products.Select(x => new ProductDto()
            {

                Id = x.Id,
                Title = x.Title,
                CategoryId = x.CategoryId,
                IsActive = x.IsActive,
                IsBid = x.IsBid,
                FactorId = x.FactorId,
                ShopId = x.ShopId,
                LastModifiedAt = x.LastModifiedAt,
                LastModifiedBy = x.LastModifiedBy,
            }
           ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
