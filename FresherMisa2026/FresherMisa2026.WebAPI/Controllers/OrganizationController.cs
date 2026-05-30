using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Application.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Organization;
using Microsoft.AspNetCore.Mvc;

namespace FresherMisa2026.WebAPI.Controllers
{
    [ApiController]
    public class OrganizationController : BaseController<Organization>
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(
            IOrganizationService organizationService) : base(organizationService)
        {
            _organizationService = organizationService;
        }

    }
}