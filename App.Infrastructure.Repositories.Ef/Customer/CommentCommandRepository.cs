using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Customer
{
    public class CommentCommandRepository : ICommentCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CommentCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(CommentDto dto, CancellationToken cancellationToken)
        {
            Comment comment = new Comment()
            {
                CustomerId = dto.CustomerId,
                ProductId = dto.ProductId,
                Description = dto.Description,
                SellerId = dto.SellerId,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted
            };
            var entityEntry = await _appDbContext.Comments.AddAsync(comment);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entityEntry.Entity.Id;

        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            _appDbContext.Comments.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return id;
        }

        public async Task<int> Update(CommentDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Comments.FirstOrDefaultAsync(c => c.Id == dto.Id);
            entity.Description = dto.Description;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            entity.CustomerId = dto.CustomerId;
            entity.ProductId = dto.ProductId;
            entity.SellerId = dto.SellerId;
            entity.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
