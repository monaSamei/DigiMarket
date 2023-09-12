using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Services
{
    public interface ICityService
    {
        Task<int> Add(CityDto dto, CancellationToken cancellationToken);
        Task<int> Update(CityDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<CityDto>> GetAll(CancellationToken cancellationToken);
        Task<CityDto?> Get(int id, CancellationToken cancellationToken);

    }
}
