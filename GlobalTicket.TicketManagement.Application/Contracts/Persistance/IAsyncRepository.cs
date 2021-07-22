﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdatedAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
