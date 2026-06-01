using Dapper;
using FresherMisa2026.Application.Extensions;
using FresherMisa2026.Application.Interfaces.Repositories;
using FresherMisa2026.Entities;
using FresherMisa2026.Entities.SalaryComposition;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace FresherMisa2026.Infrastructure.Repositories
{
    public class SalaryCompositionRepository : BaseRepository<SalaryComposition>, ISalaryCompositionRepository
    {
        public SalaryCompositionRepository(IConfiguration configuration) : base(configuration)
        {


        }



        public async Task<PagingResponse<SalaryComposition>> GetSalaryCompisitionByOrganizationName(string organizationName, PagingRequest pagingRequest)
        {
            // Normalize paging request
            if (pagingRequest == null)
                pagingRequest = new PagingRequest { PageIndex = 1, PageSize = 10 };

            if (pagingRequest.PageSize <= 0) pagingRequest.PageSize = 10;
            if (pagingRequest.PageIndex <= 0) pagingRequest.PageIndex = 1;

            string baseQuery = SQLExtension.GetQuery("Filter.SalaryComposition");

            var parameters = new DynamicParameters();
            parameters.Add("@OrganizationName", organizationName);

            // total count
            string countQuery = $"SELECT COUNT(1) FROM ({baseQuery}) AS t";
            var total = await _dbConnection.ExecuteScalarAsync<long>(countQuery, parameters, commandType: CommandType.Text);

            // paged data (MySQL LIMIT offset, count)
            int offset = (pagingRequest.PageIndex - 1) * pagingRequest.PageSize;
            parameters.Add("@Offset", offset);
            parameters.Add("@PageSize", pagingRequest.PageSize);

            string pagedQuery = $"{baseQuery} LIMIT @Offset, @PageSize";
            var data = (await _dbConnection.QueryAsync<SalaryComposition>(pagedQuery, parameters, commandType: CommandType.Text)).ToList();

            return new PagingResponse<SalaryComposition>
            {
                Total = total,
                Data = data
            };
        }
    }
}