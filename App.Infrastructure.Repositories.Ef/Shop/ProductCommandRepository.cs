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
    public class ProductCommandRepository:IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    

        public async Task<int> Add(ProductDto dto, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                Id = dto.Id,
                Title = dto.Title,
                CategoryId= dto.CategoryId,
                IsActive= dto.IsActive,
                IsBid= dto.IsBid,
                FactorId= dto.FactorId,
                ShopId= dto.ShopId,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return product.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            _appDbContext.Products.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ProductDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Products.FirstOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);
            entity.Title = dto.Title;
            entity.CategoryId = dto.CategoryId;
            entity.IsActive = dto.IsActive;
            entity.IsBid = dto.IsBid;
            entity.FactorId = dto.FactorId;
            entity.ShopId = dto.ShopId;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
    }

