using FresherMisa2026.Application.Interfaces;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Application.Interfaces.Services;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.CompositionSystem;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Services
{
    public class CompositionSystemService : BaseService<CompositionSystem>, ICompositionSystemService
    {
        private readonly ICompositionSystemRepository _compositionSystemRepository;

        public CompositionSystemService(
            IBaseRepository<CompositionSystem> baseRepository,
            ICompositionSystemRepository compositionSystemRepository            
            ) : base(baseRepository)
        {
            _compositionSystemRepository = compositionSystemRepository;
        }

    }
}