using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Repositories
{
    public interface ISuggestionCommandRepository
    {
        Task<int> Add(SuggestionDto dto, CancellationToken cancellationToken);
        Task<int> Update(SuggestionDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id,CancellationToken cancellationToken);
    }
}
