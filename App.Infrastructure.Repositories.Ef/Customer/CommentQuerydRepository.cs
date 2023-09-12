using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Customer
{
    public class CommentQuerydRepository : ICommentQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CommentQuerydRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CommentDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Comments.Select(c => new CommentDto()
            {
                Id = id,
                ProductId = c.ProductId,
                Product = c.Product.Title,
                SellerId = c.SellerId,
                //Seller=c.Seller.Name,
                CustomerId = c.CustomerId,
                Description = c.Description,
                

            }).FirstOrDefaultAsync(c => c.Id == id,cancellationToken);
            return entity;
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Comments.Select(c => new CommentDto()
            {
                Id =c.Id,
                ProductId = c.ProductId,
                Product = c.Product.Title,
                SellerId = c.SellerId,
                //Seller=c.Seller.Name,
                CustomerId = c.CustomerId,
                Description = c.Description,
               

            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
