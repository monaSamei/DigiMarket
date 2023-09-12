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
    public class ProductDetailQueryRepository:IProductDetailQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductDetailQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<ProductDetailDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductDetails.Select(x => new ProductDetailDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description= x.Description,
                ProductId= x.ProductId,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
          ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }


        public async Task<List<ProductDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.ProductDetails.Select(x => new ProductDetailDto()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                ProductId = x.ProductId,
                CreatedAt = x.CreatedAt,
                LastModifiedBy = x.LastModifiedBy,
            }
           ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
