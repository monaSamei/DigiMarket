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
    public class AddressQueryRepository : IAddressQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public AddressQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<AddressDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Addresses.Select(p => new AddressDto
            {
                Id = id,
                UserId = p.UserId,
                Title = p.Title,
                FullAddress = p.FullAddress,
                CityId = p.CityId,
                City = p.City.CityName,
                IsMainAddress = p.IsMainAddress,
                RegionTitle = p.RegionTitle,
            }).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<AddressDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Addresses.Select(p => new AddressDto
            {
                Id = p.Id,
                UserId = p.UserId,
                Title = p.Title,
                FullAddress = p.FullAddress,
                CityId = p.CityId,
                City = p.City.CityName,
                IsMainAddress = p.IsMainAddress,
                RegionTitle = p.RegionTitle,
            }).ToListAsync();
            return entities;
        }
    }
}
