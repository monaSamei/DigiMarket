using App.Domain.Core.Shop.Contract.Repositories;
using App.Domain.Core.Shop.Contract.Services;
using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Shop
{
    public class PictureService:IPictureService
    {
        private readonly IPictureCommandRepository _commandRepository;
        private readonly IPictureQueryRepository _queryRepository;

        public PictureService(IPictureCommandRepository commandRepository,IPictureQueryRepository queryRepository) 
        {
            _commandRepository = commandRepository;
           _queryRepository = queryRepository;
        }

        public async Task<int> Add(PictureDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Add(dto, cancellationToken);
            return entity;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Delete(id, cancellationToken);
            return entity;
        }

        public async Task<PictureDto> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.Get(id, cancellationToken);
            return entity;
        }

        public async Task<List<PictureDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _queryRepository.GetAll(cancellationToken);
            return entities;
        }

        public async Task<int> Update(PictureDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Update(dto, cancellationToken);
            return entity;
        }
    }
}
