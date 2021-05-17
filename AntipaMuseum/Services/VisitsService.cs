using AntipaMuseum.Core.Models;
using AntipaMuseum.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntipaMuseum.Services
{
    public class VisitsService : IVisitsService
    {
        private readonly AntipaDbContext _dbContext;

        public VisitsService(AntipaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Visit>> GetAllVisits(int visitorId)
        {
            return await _dbContext.Visits
                .Where(visit => visit.VisitorId == visitorId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Visit>> GetLastNMonthVisits(int visitorId, int lastNMonths)
        {
            if (Math.Sign(lastNMonths) == 1)
                lastNMonths *= -1;

            var visits = await _dbContext.Visits
                .OrderBy(v => v.VisitDate)
                .Where(v => 
                    (v.Id == visitorId) &&
                    (v.VisitDate > DateTimeOffset.Now.AddMonths(lastNMonths)))
                .ToListAsync();

            return visits;
        }

        public async Task<Visit> GetLastVisit(int visitorId)
        {
            return await _dbContext.Visits
                .Where(visit => visit.VisitorId == visitorId)
                .OrderBy(v => v.VisitDate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
