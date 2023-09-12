using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contract.Repositories
{
    public interface ISuggestionQueryRepository
    {
        Task<List<SuggestionDto>> GetAll(CancellationToken cancellationToken);
        Task<SuggestionDto?> Get(int id, CancellationToken cancellationToken);
    }
}
