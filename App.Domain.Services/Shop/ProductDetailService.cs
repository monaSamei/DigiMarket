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
    public class ProductDetailService:IProductDetailService

    {
        private readonly IProductDetailCommandRepository _commandRepository;
        private readonly IProductDetailQueryRepository _queryRepository;

        public ProductDetailService(IProductDetailCommandRepository commandRepository,IProductDetailQueryRepository queryRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
        }

        public async Task<int> Add(ProductDetailDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Add(dto, cancellationToken);
            return entity;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Delete(id, cancellationToken);
            return entity;
        }

        public async Task<ProductDetailDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _queryRepository.Get(id, cancellationToken);
            return entity;
        }

        public async Task<List<ProductDetailDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _queryRepository.GetAll(cancellationToken);
            return entities;
        }

        public async Task<int> Update(ProductDetailDto dto, CancellationToken cancellationToken)
        {
            var entity = await _commandRepository.Update(dto, cancellationToken);
            return entity;
        }
    }
}
