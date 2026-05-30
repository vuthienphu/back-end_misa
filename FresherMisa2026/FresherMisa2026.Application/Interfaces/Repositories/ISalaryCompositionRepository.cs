
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.SalaryComposition;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherMisa2026.Application.Interfaces.Repositories
{
    public interface ISalaryCompositionRepository : IBaseRepository<SalaryComposition>
    {

        Task<PagingResponse<SalaryComposition>> GetSalaryCompisitionByOrganizationName(string organizationName, PagingRequest pagingRequest);
    }
}
