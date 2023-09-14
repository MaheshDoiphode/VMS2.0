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

        public VisitService(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }//- Constructor

        public async Task<VisitResponseDTO> InitiateVisitAsync(InitiateVisitDTO initiateVisitDTO)
        {
            // Logic for checking if the visitor exists and populating the VisitDTO will go here
            return await _visitRepository.InitiateVisitAsync(initiateVisitDTO);
        }



    }//- Service end
}
