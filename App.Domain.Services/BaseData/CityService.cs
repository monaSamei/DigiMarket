using App.Domain.Core.BaseData.Contract.Repositories;
using App.Domain.Core.BaseData.Contract.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class CityService:ICityService
    {
        private readonly ICityCommandRepository _commandRepository;
        private readonly ICityQueryRepository _queryRepository;

        public CityService(ICityCommandRepository   commandRepository,ICityQueryRepository queryRepository) 
        {
           _commandRepository = commandRepository;
           _queryRepository = queryRepository;
        }

        public async Task<int> Add(CityDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Add(dto, cancellationToken);
            return entity;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
           var entity= await _commandRepository.Delete(id, cancellationToken);
            return entity;
        }

        public async Task<CityDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.Get(id, cancellationToken);
            return entity;
        }

        public async Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _queryRepository.GetAll(cancellationToken);
            return entities;
        }

        public async Task<int> Update(CityDto dto, CancellationToken cancellationToken)
        {
            int entity = await _commandRepository.Update(dto, cancellationToken);
            return entity;
        }
    }
}
