using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Seller.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Customer
{

    public class SuggestionQueryRepository : ISuggestionQueryRepository

    {
        private readonly AppDbContext _appDbContext;
        public SuggestionQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<SuggestionDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Suggestions.Select(s => new SuggestionDto()
            {
                Id = id,
                AcceptedSellerId = s.AcceptedSellerId,
                BidId = s.BidId,
                CustomerId = s.CustomerId,
                Description = s.Description,
                ProductId = s.ProductId,
                Product = s.Product.Title,

            }).FirstOrDefaultAsync(s => s.Id == id,cancellationToken);

            return entity;
        }

        public async Task<List<SuggestionDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Suggestions.Select(s=>new SuggestionDto()
            {
                Id= s.Id,
                AcceptedSellerId= s.AcceptedSellerId,
                BidId= s.BidId,
                CustomerId = s.CustomerId,
                DeletedAt = s.DeletedAt,
                Description = s.Description,
                IsDeleted = s.IsDeleted,
                CreatedBy = s.CreatedBy,
                ProductId = s.ProductId,

                
            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
