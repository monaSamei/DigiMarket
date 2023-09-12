using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Services
{
    public interface IPictureService
    {
        Task<int> Add(PictureDto dto, CancellationToken cancellationToken);
        Task<int> Update(PictureDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<PictureDto>> GetAll(CancellationToken cancellationToken);
        Task<PictureDto> Get(int id, CancellationToken cancellationToken);
    }
}
