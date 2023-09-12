using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Services
{
    public interface IProvinceService
    {
        Task<int> Add(ProvinceDto dto, CancellationToken cancellationToken);
        Task<int> Update(ProvinceDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken);
        Task<ProvinceDto> Get(int id, CancellationToken cancellationToken);
    }
}
