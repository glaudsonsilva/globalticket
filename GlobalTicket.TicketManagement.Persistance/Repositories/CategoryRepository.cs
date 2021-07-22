﻿using GlobalTicket.TicketManagement.Application.Contracts.Persistance;
using GlobalTicket.TicketManagement.Domain.Entities;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Persistance.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GlobalTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
        {
            var categories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();
            if (!includeHistory)
            {
                categories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return categories;
        }
    }
}
