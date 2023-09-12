using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Repositories
{
    public interface ICityCommandRepository
    {
        Task<int> Add(CityDto dto, CancellationToken cancellationToken);
        Task<int> Update(CityDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
