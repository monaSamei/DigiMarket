using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.BaseData
{
    public class ProvinceCommandRepository : IProvinceCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProvinceCommandRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(ProvinceDto dto, CancellationToken cancellationToken)
        {
            Province province = new Province();
            province.Id = dto.Id;
            province.ProvinceName = dto.ProvinceName;
            province.IsDeleted = dto.IsDeleted;
            province.CreatedBy = dto.CreatedBy;
            province.CreatedAt= DateTime.Now;
            province.DeletedBy= dto.DeletedBy;
            province.CreatedAt = DateTime.Now;
            province.LastModifiedBy= dto.LastModifiedBy;
            province.LastModifiedAt= DateTime.Now;
            var entryEntity=await _appDbContext.Provinces.AddAsync(province);
            return entryEntity.Entity.Id;
            
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity=await _appDbContext.Provinces.FirstOrDefaultAsync(p=>p.Id==id,cancellationToken);
           _appDbContext.Provinces.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(ProvinceDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Provinces.FirstOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);
            entity.ProvinceName=dto.ProvinceName;
           entity.LastModifiedAt= DateTime.Now;
            entity.LastModifiedBy= dto.LastModifiedBy;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;

        }
    }
}
