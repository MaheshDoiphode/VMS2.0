using Microsoft.EntityFrameworkCore;
using VMS2._0.Data;
using VMS2._0.DTO;
using VMS2._0.Models;
using VMS2._0.Repositories.IRepository;

namespace VMS2._0.Repositories.Repository
{
    public class VisitRepository : IVisitRepository
    {
        private readonly VMSDbContext _context;

        public VisitRepository(VMSDbContext context)
        {
            _context = context;
        }

        public async Task<VisitResponseDTO> InitiateVisitAsync(InitiateVisitDTO initiateVisitDTO)
        {
            
        }



    }//- Repository end
}
