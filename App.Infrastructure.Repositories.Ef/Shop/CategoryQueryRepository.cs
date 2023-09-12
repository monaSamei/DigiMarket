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
    public class CategoryQueryRepository:ICategoryQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CategoryDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                ParentId= x.ParentId,
                Title= x.Title,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedAt = x.LastModifiedAt,
                IsDeleted = x.IsDeleted
            }
            ).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                ParentId = x.ParentId,
                Title = x.Title,
                LastModifiedAt = x.LastModifiedAt,
                LastModifiedBy = x.LastModifiedBy,
            }
           ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
