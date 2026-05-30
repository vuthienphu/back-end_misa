using FresherMisa2026.Entities;
using FresherMisa2026.Entities.SalaryComposition;
using System.Threading.Tasks;

namespace FresherMisa2026.Application.Interfaces.Services
{
    public interface ISalaryCompositionService : IBaseService<SalaryComposition>
    {
        Task<ServiceResponse> GetByOrganizationNameAsync(string organizationName, PagingRequest pagingRequest);
    }
}