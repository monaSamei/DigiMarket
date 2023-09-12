using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Repositories
{
    public interface ICategoryCommandRepository
    {
        Task<int> Add(CategoryDto dto, CancellationToken cancellationToken);
        Task<int> Update(CategoryDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
