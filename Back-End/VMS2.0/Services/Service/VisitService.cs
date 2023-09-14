using VMS2._0.DTO;
using VMS2._0.Models;
using VMS2._0.Repositories.IRepository;
using VMS2._0.Services.IService;
using System.Threading.Tasks;

namespace VMS2._0.Services.Service
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IVisitorRepository _visitorRepository;

        public VisitService(IVisitRepository visitRepository, IVisitorRepository visitorRepository)
        {
            _visitRepository = visitRepository;
            _visitorRepository = visitorRepository;
        }//- Constructor end

        public async Task<int> InitiateVisitAsync(InitiateVisitDTO initiateVisitDto)
        {
            // Check if visitor exists
            var existingVisitor = await _visitorRepository.GetVisitorByEmailAsync(initiateVisitDto.VisitorEmail);

            if (existingVisitor == null)
            {
                // Create a new visitor with the provided details
                VisitorDTO newVisitor = new VisitorDTO
                {
                    VisitorEmail = initiateVisitDto.VisitorEmail,
                    // Populate other fields from InitiateVisitDTO as necessary
                    // For now, I'm assuming InitiateVisitDTO has the following fields:
                    Title = initiateVisitDto.Title,
                    FName = initiateVisitDto.FName,
                    LName = initiateVisitDto.LName,
                    VisitorNumber = initiateVisitDto.VisitorNumber,
                    // Leave other fields as they are for later updates
                };

                // Save the new visitor and get the generated VisitorID
                existingVisitor = await _visitorRepository.CreateVisitorAsync(newVisitor);
            }

            // Populate DTO with existing information if visitor exists or the newly created visitor
            VisitDTO visitDto = new VisitDTO
            {
                VisitorID = existingVisitor.VisitorID,
                HostName = initiateVisitDto.HostName, // Assuming the InitiateVisitDTO has a HostName
                HostEmail = initiateVisitDto.HostEmail, // Assuming the InitiateVisitDTO has a HostEmail
                Purpose = initiateVisitDto.Purpose,
                ExpectedArrival = initiateVisitDto.ExpectedArrival,
                ExpectedDepart = initiateVisitDto.ExpectedDepart,
                // Add other fields as necessary
            };

            // Initiate visit
            var visitId = await _visitRepository.InitiateVisitAsync(visitDto);

            return visitId;  // This will be a positive integer if successful, or a negative value/error code if failed.
        }//- IntitiateVisit end
    }//- Service end
}
