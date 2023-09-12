using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Infrastructure.Repositories.Ef.Customer
{
    public class AddressCommandRepository : IAddressCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public AddressCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(AddressDto dto, CancellationToken cancellationToken)
        {
            Address address = new Address();
            address.FullAddress = dto.FullAddress;
            address.IsMainAddress = dto.IsMainAddress;
            address.UserId = dto.UserId;
            address.CityId = dto.CityId;
            address.CreatedAt = DateTime.Now;
            address.CreatedBy = dto.CreatedBy;
            address.RegionTitle = dto.RegionTitle;
            address.Title = dto.Title;
            address.IsDeleted = true;
            var entityEntery = await _appDbContext.Addresses.AddAsync(address);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entityEntery.Entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var address = _appDbContext.Addresses.FirstOrDefault(p => p.Id == id);
            _appDbContext.Remove(address);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return address.Id;
        }

        public async Task<int> Update(AddressDto dto, CancellationToken cancellationToken)
        {

            Address address = await _appDbContext.Addresses.FirstOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);
            address.FullAddress = dto.FullAddress;
            address.IsMainAddress = dto.IsMainAddress;
            address.UserId = dto.UserId;
            address.CityId = dto.CityId;
            address.RegionTitle = dto.RegionTitle;
            address.Title = dto.Title;
            address.LastModifiedAt= DateTime.Now;
            address.LastModifiedBy= dto.LastModifiedBy;
            address.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return address.Id;

        }
    }
}
