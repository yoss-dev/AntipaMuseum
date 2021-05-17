using AntipaMuseum.Core.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AntipaMuseum.Services
{
    public interface IVisitorService
    {
        Task DeleteVisitor(int visitorId);
        Task<IEnumerable<Visitor>> GetAll();
        Task<Visitor> GetVisitorById(int visitorId);
        Task UpdateVisitor(int visitorId, Visitor visitor);
        Task<bool> Exists(int visitorId);
    }
}