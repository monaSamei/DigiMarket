using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface ICategoryQueryRepository
    {
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
        Task<CategoryDto?> Get(int id,CancellationToken cancellationToken);

    }
}
