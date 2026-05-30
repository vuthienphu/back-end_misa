using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.SalaryComposition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FresherMisa2026.Application.Services
{
    public class SalaryCompositionService : BaseService<SalaryComposition>, ISalaryCompositionService
    {
        private readonly ISalaryCompositionRepository _salaryCompositionRepository;

        public SalaryCompositionService(
            IBaseRepository<SalaryComposition> baseRepository,
            ISalaryCompositionRepository salaryCompositionRepository
            ) : base(baseRepository)
        {
            _salaryCompositionRepository = salaryCompositionRepository;
        }

        public async Task<ServiceResponse> GetByOrganizationNameAsync(string organizationName, PagingRequest pagingRequest)
        {
          
            // normalize pagingRequest
            if (pagingRequest == null)
                pagingRequest = new PagingRequest { PageIndex = 1, PageSize = 10 };

            if (pagingRequest.PageSize <= 0) pagingRequest.PageSize = 10;
            if (pagingRequest.PageIndex <= 0) pagingRequest.PageIndex = 1;

            var pagingResult = await _salaryCompositionRepository.GetSalaryCompisitionByOrganizationName(organizationName, pagingRequest);
            return CreateSuccessResponse(pagingResult);
        }

        protected override List<ValidationError> ValidateCustom(SalaryComposition salaryComposition)
        {
            var errors = new List<ValidationError>();

            
            if (!string.IsNullOrEmpty(salaryComposition.SalaryCompositionCode) && salaryComposition.SalaryCompositionCode.Length > 255)
            {
                errors.Add(new ValidationError("SalaryCompositionCode", "Mã thành phần lương không được vượt quá 255 ký tự"));
            }


            if (!string.IsNullOrEmpty(salaryComposition.SalaryCompositionName) && salaryComposition.SalaryCompositionName.Length > 255)
            {
                errors.Add(new ValidationError("SalaryCompositionName", "Tên thành phần lương không được vượt quá 255 ký tự"));
            }

            return errors;
        }

    }
}