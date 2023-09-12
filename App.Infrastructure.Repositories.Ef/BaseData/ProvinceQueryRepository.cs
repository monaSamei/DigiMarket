using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.BaseData
{
    public class ProvinceQueryRepository:IProvinceQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProvinceQueryRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task<ProvinceDto> Get(int id, CancellationToken cancellationToken)
        {
            var entity=await _appDbContext.Provinces.Select(p => new ProvinceDto()
            {
                Id =p.Id,
                CreatedAt= p.CreatedAt,
                CreatedBy=p.CreatedBy,
                DeletedAt=p.DeletedAt,
                DeletedBy=p.DeletedBy,
                IsDeleted=false,
                LastModifiedAt= p.LastModifiedAt,
                LastModifiedBy=p.LastModifiedBy,
                ProvinceName = p.ProvinceName,
            }
            ).FirstOrDefaultAsync(p=>p.Id==id,cancellationToken);
            return entity;
        }

        public async Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Provinces.Select(p => new ProvinceDto()
            {
                Id = p.Id,
                CreatedBy = p.CreatedBy,
                DeletedBy = p.DeletedBy,
                IsDeleted = false,
                LastModifiedBy=p.LastModifiedBy,
                ProvinceName = p.ProvinceName,
            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}