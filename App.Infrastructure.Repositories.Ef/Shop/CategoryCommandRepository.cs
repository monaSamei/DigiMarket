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
    public  class CategoryCommandRepository:ICategoryCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CategoryCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(CategoryDto dto, CancellationToken cancellationToken)
        {
            Category category = new Category()
            {
                Id = dto.Id,
                ParentId = dto.ParentId,
                Title = dto.Title,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            await _appDbContext.Categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return category.Id;
        }
            public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            _appDbContext.Categories.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(CategoryDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Categories.FirstOrDefaultAsync(c => c.Id == dto.Id, cancellationToken);
            entity.ParentId = dto.ParentId;
            entity.Title = dto.Title;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
