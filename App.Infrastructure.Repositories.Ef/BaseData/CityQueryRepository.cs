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
    public class CityQueryRepository : ICityQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CityQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<CityDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Cities.Select(s => new CityDto()
            {
                Id = s.Id,
                CityName = s.CityName,
                CreatedAt = s.CreatedAt,
                CreatedBy = s.CreatedBy,
                DeletedAt = s.DeletedAt,
                DeletedBy = s.DeletedBy,
                IsDeleted = s.IsDeleted,
            }
            ).FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            return entity;

        }

        public Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = _appDbContext.Cities.Select(c => new CityDto()
            {
                Id = c.Id,
                CityName = c.CityName,
                CreatedBy = c.CreatedBy,
                DeletedBy = c.DeletedBy,
                IsDeleted = c.IsDeleted,
            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
