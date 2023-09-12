using App.Domain.Core.Customer.Contract.Repositories;
using CustomerEntity = App.Domain.Core.Customer.Entities;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructure.SqlServers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories.Ef.Customer
{
    public class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> Add(CustomerDto dto, CancellationToken cancellationToken)
        {
            CustomerEntity.Customer customer = new CustomerEntity.Customer()
            {
                CreatedAt = DateTime.Now,
                UserId = dto.UserId,
                CreatedBy = dto.CreatedBy,
                LastModifiedBy = dto.LastModifiedBy,
                LastModifiedAt = DateTime.Now,
                DeletedAt = DateTime.Now,
                IsDeleted = dto.IsDeleted,
                DeletedBy = dto.DeletedBy,
            };
            await _appDbContext.Customers.AddAsync(customer);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return customer.Id;

        }


        public async Task<int> Delete(int id, CancellationToken cancellationToken)
        {
            var entity=await _appDbContext.Customers.FirstOrDefaultAsync(c=> c.Id == id,cancellationToken);
           
              _appDbContext.Customers.Remove(entity);
                await _appDbContext.SaveChangesAsync(cancellationToken) ;
            return entity.Id;
        }

        public async Task<int> Update(CustomerDto dto, CancellationToken cancellationToken)
        {
            var entity=await _appDbContext.Customers.FirstOrDefaultAsync(c=>c.Id == dto.Id,cancellationToken);
            entity.LastModifiedAt= DateTime.Now;
            entity.LastModifiedBy= dto.LastModifiedBy;
            entity.UserId= dto.UserId;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
