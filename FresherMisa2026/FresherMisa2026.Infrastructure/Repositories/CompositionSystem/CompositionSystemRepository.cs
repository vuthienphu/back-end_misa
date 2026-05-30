using Dapper;
using FresherMisa2026.Application.Extensions;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Entities.CompositionSystem;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FresherMisa2026.Infrastructure.Repositories
{
    public class CompositionSystemRepository : BaseRepository<CompositionSystem>, ICompositionSystemRepository
    {
        public CompositionSystemRepository(IConfiguration configuration) : base(configuration)
        {
        }

       
    }
}