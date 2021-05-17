using AntipaMuseum.Core.Models;
using AntipaMuseum.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntipaMuseum.Services
{
    public class VisitorService
    {
        private readonly AntipaDbContext _dbContext;

        public VisitorService(AntipaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Visitor>> GetAll()
        {
            return await _dbContext.Visitors
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Visitor> GetVisitorById(int visitorId)
        {
            return await _dbContext.Visitors.FirstOrDefaultAsync(v => v.Id == visitorId);
        }

        public async Task DeleteVisitor(int visitorId)
        {
            if (await Exists(visitorId))
            {
                var existingEntity = await _dbContext.Visitors.FirstAsync(v => v.Id == visitorId);
                _dbContext.Visitors.Remove(existingEntity);
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task<bool> Exists(int visitorId)
        {
            return await _dbContext.Visitors.FirstOrDefaultAsync(v => v.Id == visitorId) != null;
        }
    }
}
