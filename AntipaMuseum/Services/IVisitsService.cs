using AntipaMuseum.Core.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntipaMuseum.Services
{
    public interface IVisitsService
    {
        Task<IEnumerable<Visit>> GetAllVisits(int visitorId);
        Task<Visit> GetLastVisit(int visitorId);
        Task<IEnumerable<Visit>> GetLastNMonthVisits(int visitorId, int lastNMonths);
    }
}