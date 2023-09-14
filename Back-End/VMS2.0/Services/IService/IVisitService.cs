using VMS2._0.DTO;

namespace VMS2._0.Services.IService
{
    public interface IVisitService
    {
        Task<int> InitiateVisitAsync(InitiateVisitDTO initiateVisitDto);
    }
}
