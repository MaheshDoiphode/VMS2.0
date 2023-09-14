using VMS2._0.Models;
using System.Threading.Tasks;
using VMS2._0.DTO;

namespace VMS2._0.Repositories.IRepository
{
    public interface IVisitRepository
    {
        Task<int> InitiateVisitAsync(VisitDTO visitDto);
        Task<VisitorDTO?> GetVisitorByEmailAsync(string email);
    }
}
