using App.Domain.Core.Seller.Cantract.Repositories;
using App.Domain.Core.Seller.Dtos;
using SellerEntity = App.Domain.Core.Seller.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Infrastructure.Repositories.Ef.Seller
{
    public class SellerCommandRepository : ISellerCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public SellerCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(SellerDto dto, CancellationToken cancellationToken)
        {
            SellerEntity.Seller seller = new SellerEntity.Seller();
            seller.Id = dto.Id;
            seller.AddressId = dto.AddressId;
            seller.DeletedBy = dto.DeletedBy;
            seller.CreatedBy = dto.CreatedBy;
            var entityEntry = await _appDbContext.Sellers.AddAsync(seller);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entityEntry.Entity.Id;

        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Sellers.FirstOrDefaultAsync(s => s.Id == id,cancellationToken);
            _appDbContext.Sellers.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }

        public async Task<int> Update(SellerDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Sellers.FirstOrDefaultAsync(s=>s.Id==dto.Id,cancellationToken);
            entity.AddressId = dto.AddressId;
            entity.DeletedBy = dto.DeletedBy;
            entity.CreatedBy = dto.CreatedBy;
            entity.DeletedBy = dto.DeletedBy;
           await _appDbContext.Sellers.AddAsync(entity);
            return entity.Id;
                
        }
    }
}
