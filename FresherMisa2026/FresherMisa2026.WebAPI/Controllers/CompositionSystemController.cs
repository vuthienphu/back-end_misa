using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.CompositionSystem;
using Microsoft.AspNetCore.Mvc;

namespace FresherMisa2026.WebAPI.Controllers
{
    [ApiController]
    public class CompositionSystemController : BaseController<CompositionSystem>
    {
        private readonly ICompositionSystemService _compositionSystemService;

        public CompositionSystemController(
            ICompositionSystemService compositionSystemService) : base(compositionSystemService)
        {
            _compositionSystemService = compositionSystemService;
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

            var response = await _compositionSystemService.GetFilterPagingAsync(pagingRequest);
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

            var response = await _compositionSystemService.GetFilterPagingAsync(pagingRequest);
            return Ok(response);
        }
    }
}