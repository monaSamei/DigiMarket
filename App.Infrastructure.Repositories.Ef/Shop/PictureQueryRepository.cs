using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class PictureQueryRepository:IPictureQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public PictureQueryRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<PictureDto> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Pictures.Select(p=>new PictureDto() {
                Id= p.Id,
                PictureUrl = p.PictureUrl,
                PictureTypes = p.PictureTypes,        
                CreatedAt =p.CreatedAt,
                CreatedBy = p.CreatedBy,
                LastModifiedAt = p.LastModifiedAt,
                LastModifiedBy = p.LastModifiedBy,

            }).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            return entity;
        }

        public async Task<List<PictureDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Pictures.Select(p => new PictureDto()
            {
                Id = p.Id,
                PictureUrl = p.PictureUrl,
                PictureTypes = p.PictureTypes,
                CreatedAt = p.CreatedAt,
                CreatedBy = p.CreatedBy,
                LastModifiedAt = p.LastModifiedAt,
                LastModifiedBy = p.LastModifiedBy,

            }).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
