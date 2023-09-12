using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Services
{
    public interface ISuggestionService
    {
        Task<List<SuggestionDto>> GetAll(CancellationToken cancellationToken);
        Task<SuggestionDto?> Get(int id, CancellationToken cancellationToken);
        Task<int> Add(SuggestionDto dto, CancellationToken cancellationToken);
        Task<int> Update(SuggestionDto dto, CancellationToken cancellationToken);
        Task<int> Delete(int id, CancellationToken cancellationToken);
    }
}
