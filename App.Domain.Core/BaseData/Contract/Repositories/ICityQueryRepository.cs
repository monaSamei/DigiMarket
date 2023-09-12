using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface ICityQueryRepository
    {
        Task<List<CityDto>> GetAll(CancellationToken cancellationToken);
        Task<CityDto?> Get(int id, CancellationToken cancellationToken);
    }
}
