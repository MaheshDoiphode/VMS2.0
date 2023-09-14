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
        }//- Contructor

        public async Task<int> InitiateVisitAsync(VisitDTO visitDto)
        {
            // Convert DTO to Model
            Visit visit = new Visit
            {
                VisitorID = visitDto.VisitorID,
                HostName = visitDto.HostName,
                HostEmail = visitDto.HostEmail,
                Purpose = visitDto.Purpose,
                ExpectedArrival = visitDto.ExpectedArrival,
                ExpectedDepart = visitDto.ExpectedDepart,
            };

            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            return visit.VisitID;
        }

        public async Task<VisitorDTO?> GetVisitorByEmailAsync(string email)
        {
            // First, try to find the visitor directly by their primary email
            var visitor = await _context.Visitors
                .Select(v => new VisitorDTO
                {
                    VisitorID = v.VisitorID,
                    Title = v.Title,
                    FName = v.FName,
                    LName = v.LName,
                    VisitorEmail = v.VisitorEmail,
                    VisitorNumber = v.VisitorNumber,
                    VisitorAddress = v.VisitorAddress,
                    IdentityType = v.IdentityType,
                    IdentityNumber = v.IdentityNumber,
                    Image = v.Image
                })
                .FirstOrDefaultAsync(v => v.VisitorEmail == email);

            if (visitor != null)
            {
                return visitor;
            }

            // If not found, check the SecondaryInfo table for the alternate email
            var secondaryInfo = await _context.SecondaryInfos.FirstOrDefaultAsync(s => s.AlternateEmail == email);

            if (secondaryInfo != null)
            {
                // Fetch the associated visitor using the VisitorID from the SecondaryInfo record
                return await _context.Visitors
                    .Select(v => new VisitorDTO
                    {
                        VisitorID = v.VisitorID,
                        Title = v.Title,
                        FName = v.FName,
                        LName = v.LName,
                        VisitorEmail = v.VisitorEmail,
                        VisitorNumber = v.VisitorNumber,
                        VisitorAddress = v.VisitorAddress,
                        IdentityType = v.IdentityType,
                        IdentityNumber = v.IdentityNumber,
                        Image = v.Image
                    })
                    .FirstOrDefaultAsync(v => v.VisitorID == secondaryInfo.VisitorID);
            }

            return null; // Return null if no match is found in both tables
        }



    }//- Repository end
}
