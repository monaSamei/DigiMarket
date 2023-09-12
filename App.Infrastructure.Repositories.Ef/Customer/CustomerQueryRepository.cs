using App.Domain.Core.Customer.Contract.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories.Ef.Customer
{
    public class CustomerQueryRepository : ICustomerQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CustomerQueryRepository() 
        { 
            _appDbContext = new AppDbContext();
        }
        public async Task<CustomerDto?> Get(int id, CancellationToken cancellationToken)
        {
            var entity = await _appDbContext.Customers.Select(c => new CustomerDto()
            {
                Id = id,
                UserId= c.UserId,
                
              
            }
            ).FirstOrDefaultAsync(c => c.Id == id,cancellationToken);
            return entity;
        }

        public async Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _appDbContext.Customers.Select(c => new CustomerDto()
            {
                Id = c.Id,
                UserId = c.UserId,
            }
            ).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
