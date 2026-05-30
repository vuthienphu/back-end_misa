using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Application.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Enums;
using FresherMisa2026.Entities.SalaryComposition;
using Microsoft.AspNetCore.Mvc;

namespace FresherMisa2026.WebAPI.Controllers
{
    [ApiController]
    public class SalaryCompositionController : BaseController<SalaryComposition>
    {
        private readonly ISalaryCompositionService _salaryCompositionService;

        public SalaryCompositionController(
            ISalaryCompositionService salaryCompositionService) : base(salaryCompositionService)
        {
            _salaryCompositionService = salaryCompositionService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<ServiceResponse>> SearchByCodeOrName(
           [FromQuery] string? searchValue,
           [FromQuery] int pageSize = 10,
           [FromQuery] int pageIndex = 1,
           [FromQuery] string? sort = null)
        {
            var pagingRequest = new PagingRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Search = searchValue ?? string.Empty,
                Sort = sort ?? string.Empty,

                SearchFields = "SalaryCompositionCode;SalaryCompositionName"
            };

            var response = await _salaryCompositionService.GetFilterPagingAsync(pagingRequest);
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<ActionResult<ServiceResponse>> Filter(
    [FromQuery] int? isActive,
    [FromQuery] string? compositionType,
    [FromQuery] int pageSize = 10,
    [FromQuery] int pageIndex = 1,
    [FromQuery] string? sort = null)
        {
            string searchValue = string.Empty;


            if (!string.IsNullOrEmpty(compositionType))
            {
                searchValue = compositionType;
            }
            else if (isActive.HasValue)
            {
                searchValue = isActive.Value.ToString();
            }

            var pagingRequest = new PagingRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Search = searchValue,
                Sort = sort ?? string.Empty,


                SearchFields = "IsActive;CompositionType"
            };

            var response = await _salaryCompositionService.GetFilterPagingAsync(pagingRequest);
            return Ok(response);
        }

        [HttpGet("by-organization")]
        public async Task<ActionResult<ServiceResponse>> GetByOrganizationName(
            [FromQuery] string organizationName,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 1,
            [FromQuery] string? sort = null)
        {
            var pagingRequest = new PagingRequest
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Sort = sort ?? string.Empty
            };

            var response = await _salaryCompositionService.GetByOrganizationNameAsync(organizationName, pagingRequest);

            if (!response.IsSuccess && response.Code == (int)ResponseCode.BadRequest)
                return BadRequest(response);

            return Ok(response);
        }

    }
}