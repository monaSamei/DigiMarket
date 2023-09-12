using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.BaseData
{
    public class SiteCommandRepository:ISiteCommandRepository
    {
        private readonly AppDbContext _appDbcontext;
        public SiteCommandRepository(AppDbContext appDbContext) {
            _appDbcontext = appDbContext;
        }

        public async Task<int> Add(SiteDto dto, CancellationToken cancellationToken)
        {
            Site site=new Site();
            site.Id = dto.Id;
            site.Comission=dto.Comission;
            site.LastModifiedAt=DateTime.Now;
            site.LastModifiedBy=dto.LastModifiedBy;
            site.CreatedBy=dto.CreatedBy;
            site.CreatedAt=DateTime.Now;
            site.DeletedBy=dto.DeletedBy;
            site.DeletedAt=DateTime.Now;
            site.LastModifiedAt = DateTime.Now;
            site.LastModifiedBy = dto.LastModifiedBy;
            site.IsDeleted = false;
            var entityEntry = await _appDbcontext.Sites.AddAsync(site);
           await _appDbcontext.SaveChangesAsync(cancellationToken);
            return entityEntry.Entity.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity= await _appDbcontext.Sites.FirstOrDefaultAsync(s=>s.Id==id,cancellationToken);
            _appDbcontext.Sites.Remove(entity);
            await _appDbcontext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(SiteDto dto, CancellationToken cancellationToken)
        {
          var entity=await _appDbcontext.Sites.FirstOrDefaultAsync(s=>s.Id==dto.Id,cancellationToken);
            entity.Id = dto.Id;
            entity.Comission = dto.Comission;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
           
            await _appDbcontext.SaveChangesAsync(cancellationToken);
            return entity.Id;


        }
    }
}
