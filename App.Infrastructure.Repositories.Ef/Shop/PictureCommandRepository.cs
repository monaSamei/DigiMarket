using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Dtos;
using App.Domain.Core.Shop.Entities;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Shop
{
    public class PictureCommandRepository : IPictureCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public PictureCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> Add(PictureDto dto, CancellationToken cancellationToken)
        {
            Picture picture = new Picture()
            {
                Id = dto.Id,
                PictureUrl = dto.PictureUrl,
                PictureTypes = dto.PictureTypes,
                ProductId = dto.ProductId,
                CreatedAt = DateTime.Now,
                CreatedBy = dto.CreatedBy,
                LastModifiedAt = DateTime.Now,
                LastModifiedBy = dto.LastModifiedBy,
            };
            await _appDbContext.Pictures.AddAsync(picture);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return picture.Id;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Pictures.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            _appDbContext.Pictures.Remove(entity);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task<int> Update(PictureDto dto, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Pictures.FirstOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);
            entity.Id = dto.Id;
            entity.PictureUrl = dto.PictureUrl;
            entity.PictureTypes = dto.PictureTypes;
            entity.ProductId = dto.ProductId;
            entity.LastModifiedAt = DateTime.Now;
            entity.LastModifiedBy = dto.LastModifiedBy;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
