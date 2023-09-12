using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface IProvinceQueryRepository
    {
        Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken);
        Task<ProvinceDto> Get(int id,CancellationToken cancellationToken);
    }
}
