using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contract.Services
{
    public interface ISiteService
    {
        Task<int> Add(SiteDto dto, CancellationToken cancellationToken);
        Task<int> Update(SiteDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<SiteDto>> GetAll(CancellationToken cancellationToken);
        Task<SiteDto> Get(int id, CancellationToken cancellationToken);
    }
}
