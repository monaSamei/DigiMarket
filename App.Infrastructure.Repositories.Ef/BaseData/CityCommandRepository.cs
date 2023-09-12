using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.BaseData
{
    public class CityCommandRepository:ICityCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CityCommandRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;

        }

        public async Task<int> Add(CityDto dto, CancellationToken cancellationToken)
        {
            City city = new City();
            city.CityName = dto.CityName;
            city.ProvinceId = dto.ProvinceId;
            city.CreatedAt = DateTime.Now;
            city.CreatedBy = dto.CreatedBy;
            city.DeletedBy = dto.DeletedBy;
            city.LastModifiedAt= DateTime.Now;
            city.LastModifiedBy= dto.LastModifiedBy;
           var entityEntry= await _appDbContext.AddAsync(city);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entityEntry.Entity.Id;

        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Cities.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            _appDbContext.Cities.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(CityDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Cities.FirstOrDefaultAsync(c => c.Id == dto.Id, cancellationToken);
            entity.CityName=dto.CityName;
            entity.CreatedAt=dto.CreatedAt;
            entity.CreatedBy=dto.CreatedBy;
            entity.DeletedBy=dto.DeletedBy;
            entity.IsDeleted=dto.IsDeleted;
            entity.LastModifiedBy=dto.LastModifiedBy;
            entity.LastModifiedAt=DateTime.Now;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
