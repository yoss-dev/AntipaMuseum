using AntipaMuseum.Core.Models;
using AntipaMuseum.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntipaMuseum.Services
{
    public class VisitorService : IVisitorService
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

        public async Task<int> CreateVisitor(Visitor visitor)
        {
            _dbContext.Add(visitor);
            await _dbContext.SaveChangesAsync();

            return visitor.Id;
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

        public async Task<bool> Exists(int visitorId)
        {
            return await _dbContext.Visitors.FirstOrDefaultAsync(v => v.Id == visitorId) != null;
        }

        /// <summary>
        /// Updates a visitor. Asumes the passed in visitorId corresponds to a valid visitor in the databse.
        /// The passed in Visitor.Id will be ignored.
        /// </summary>
        /// <param name="visitor"></param>
        /// <returns></returns>
        public async Task UpdateVisitor(int visitorId, Visitor visitor)
        {
            var existingEntity = await _dbContext.Visitors.FirstAsync(v => v.Id == visitorId);

            existingEntity.Age = visitor.Age;
            existingEntity.Gender = visitor.Gender;

            await _dbContext.SaveChangesAsync();
        }
    }
}
