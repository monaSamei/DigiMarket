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
    public class CommentService : ICommentService
    {
        private readonly ICommentCommandRepository _commandRepository;
        private readonly ICommentQueryRepository _queryRepository;

        public CommentService(ICommentCommandRepository commentCommandRepository,ICommentQueryRepository commentQueryRepository) 
        {
            _commandRepository = commentCommandRepository;
            _queryRepository = commentQueryRepository;
        }
        public async Task<int> Add(CommentDto dto, CancellationToken cancellationToken)
        {
          var entity = await _commandRepository.Add(dto, cancellationToken);
            return entity;
        }

        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
           var entity= await _commandRepository.Delete(id, cancellationToken);
            return entity;
        }

        public async Task<CommentDto?> Get(int id, CancellationToken cancellationToken)
        {
           var entity= await _queryRepository.Get(id, cancellationToken);
            return entity;

        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities=await _queryRepository.GetAll(cancellationToken);
            return entities;
        }

        public async Task<int> Update(CommentDto dto, CancellationToken cancellationToken)
        {
            var entity= await _commandRepository.Update(dto, cancellationToken);          
            return entity;
        }
    }
}
