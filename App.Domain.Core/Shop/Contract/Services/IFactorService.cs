﻿using App.Domain.Core.Shop.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Shop.Contract.Services
{
    public interface IFactorService
    {
        Task<int> Add(FactorDto dto, CancellationToken cancellationToken); 
        Task<int> Update(FactorDto dto, CancellationToken cancellationToken); 
        Task<int> Delete(int id, CancellationToken cancellationToken);
        Task<List<FactorDto>> GetAll(CancellationToken cancellationToken);
        Task<FactorDto?> Get(int id, CancellationToken cancellationToken);
    }
}
