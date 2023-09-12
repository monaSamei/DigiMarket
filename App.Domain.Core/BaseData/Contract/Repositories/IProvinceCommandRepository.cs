using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface IProvinceCommandRepository
    {
        Task<int> Add(ProvinceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ProvinceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
