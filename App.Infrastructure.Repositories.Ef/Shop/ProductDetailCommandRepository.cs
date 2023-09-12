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
    public class ProductDetailCommandRepository:IProductDetailCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductDetailCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(ProductDetailDto dto, CancellationToken cancellationToken)
        {
            ProductDetail detail = new ProductDetail()
            {
                Id = dto.Id,
                ProductId= dto.ProductId,
                Description= dto.Description,
                Title = dto.Title,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.ProductDetails.AddAsync(detail);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return detail.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductDetails.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            _appDbContext.ProductDetails.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ProductDetailDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.ProductDetails.FirstOrDefaultAsync(c => c.Id == dto.Id, cancellationToken);
            entity.ProductId = dto.ProductId;
            entity.Title = dto.Title;
            entity.Description= dto.Description;
            entity.Title = dto.Title;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
