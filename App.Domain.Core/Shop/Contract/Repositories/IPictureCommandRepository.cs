using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface IPictureCommandRepository
    {
        Task<int> Add(PictureDto dto, CancellationToken cancellationToken);
        Task<int> Update(PictureDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
