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
    public class SiteQueryRepository : ISiteQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public SiteQueryRepository(AppDbContext appDbContext) 
        {
        _appDbContext= appDbContext;
        }
        public async Task<SiteDto> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Sites.Select(s => new SiteDto() {
            Id=s.Id,
            Comission=s.Comission,
            CreatedAt=s.CreatedAt,
            CreatedBy=s.CreatedBy,
            DeletedAt=s.DeletedAt,
            DeletedBy=s.DeletedBy, 
            IsDeleted=s.IsDeleted,
            LastModifiedAt=s.LastModifiedAt,
            LastModifiedBy=s.LastModifiedBy,
            }).FirstOrDefaultAsync(s=>s.Id==id,cancellationToken);
            return entity;
        }

        public async Task<List<SiteDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Sites.Select(s => new SiteDto() 
            {
                Id=s.Id,
                LastModifiedBy=s.LastModifiedBy,
                CreatedBy=s.CreatedBy,
                Comission=s.Comission,
                DeletedBy=s.DeletedBy,  
                IsDeleted = s.IsDeleted,
            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
