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
    public class SuggestionCommandRepository : ISuggestionCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public SuggestionCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(SuggestionDto dto, CancellationToken cancellationToken)
        {
            Suggestion suggestion = new Suggestion()
            {
                SuggestStatus = dto.SuggestStatus,
                SuggestRegDate = dto.SuggestRegDate,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                ProductId = dto.ProductId,
                CustomerId = dto.CustomerId,
                BidId = dto.BidId,
                AcceptedSellerId = dto.AcceptedSellerId,
                ScoreByCustomerId = dto.ScoreByCustomerId,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                IsDeleted = dto.IsDeleted
            };
            var entityEntry = await _appDbContext.Suggestions.AddAsync(suggestion);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entityEntry.Entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
           var suggestion=_appDbContext.Suggestions.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
            _appDbContext.Remove(suggestion);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return suggestion.Id;
        }

        public async Task<int> Update(SuggestionDto dto, CancellationToken cancellationToken)
        {
            Suggestion suggestion=await _appDbContext.Suggestions.FirstOrDefaultAsync(x=>x.Id == dto.Id,cancellationToken);
            suggestion.SuggestStatus = dto.SuggestStatus;
            suggestion.SuggestRegDate = dto.SuggestRegDate;
            suggestion.Description = dto.Description;
            suggestion.ProductId = dto.ProductId;
            suggestion.CustomerId = dto.CustomerId;
            suggestion.BidId = dto.BidId;
            suggestion.AcceptedSellerId = dto.AcceptedSellerId;
            suggestion.ScoreByCustomerId = dto.ScoreByCustomerId;
            suggestion.LastModifiedBy = dto.LastModifiedBy;
            suggestion.LastModifiedAt= DateTime.Now;
            suggestion.IsDeleted = dto.IsDeleted;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return suggestion.Id;
        }
    }
}
