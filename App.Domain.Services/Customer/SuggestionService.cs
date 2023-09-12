using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Contract.Services;
using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Customer
{
    public class SuggestionService:ISuggestionService
    {
        private readonly ISuggestionCommandRepository _commandRepository;
        private readonly ISuggestionQueryRepository _queryRepository;

        public SuggestionService(ISuggestionCommandRepository commandRepository,ISuggestionQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<int> Add(SuggestionDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Add(dto, cancellationToken);
            return entity;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Delete(id, cancellationToken);
            return entity;
        }

        public async Task<SuggestionDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.Get(id, cancellationToken);
            return entity;
        }

        public async Task<List<SuggestionDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _queryRepository.GetAll(cancellationToken);
            return entities;
        }

        public async Task<int> Update(SuggestionDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Update(dto, cancellationToken);
            return entity;
        }
    }
}
