using FresherMisa2026.Entities;
using System;
using System.Collections.Generic;

namespace FresherMisa2026.Application.Interfaces.Services
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách bản ghi</returns>
       
        Task<ServiceResponse> GetEntitiesAsync();

        /// <summary>
        /// Lấy bản ghi theo id
        /// </summary>
        /// <param name="entityId">Id của bản ghi</param>
        /// <returns>Bản ghi thông tin 1 bản ghi</returns>
        
        Task<ServiceResponse> GetEntityByIDAsync(Guid entityId);

        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <returns>ServiceResponse</returns>
        
        Task<ServiceResponse> DeleteByIDAsync(Guid entityId);

        /// <summary>
        /// Thêm một thực thể
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <returns>ServiceResponse</returns>
        
        Task<ServiceResponse> InsertAsync(TEntity entity);

        /// <summary>
        /// Cập nhập thông tin bản ghi 
        /// </summary>
        /// <param name="entityId">Id bản ghi</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>ServiceResponse</returns>
       
        Task<ServiceResponse> UpdateAsync(Guid entityId, TEntity entity);

        /// <summary>
        /// Lấy danh sách thực thể paging
        /// </summary>
        /// <param name="pagingRequest">Thông tin phân trang</param>
        /// <returns>Danh sách thực thể phân trang</returns>
       
        Task<ServiceResponse> GetFilterPagingAsync(PagingRequest pagingRequest);

        Task<ServiceResponse> DuplicateAsync(Guid entityId, TEntity entity);

        Task<ServiceResponse> DeleteMultipleAsync(List<Guid> ids);
    }
}