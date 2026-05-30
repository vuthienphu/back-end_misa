using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.Organization;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Services
{
    public class OrganizationService : BaseService<Organization>, IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(
            IBaseRepository<Organization> baseRepository,
            IOrganizationRepository organizationRepository
            ) : base(baseRepository)
        {
            _organizationRepository = organizationRepository;
        }


        
    }
}