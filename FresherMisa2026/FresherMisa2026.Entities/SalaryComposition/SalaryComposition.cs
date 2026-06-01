using FresherMisa2026.Entities.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FresherMisa2026.Entities.SalaryComposition
{
    [ConfigTable("Pa_Salary_Composition", false, "SalaryCompositionCode")]
    public class SalaryComposition : BaseModel
    {
        /// <summary>
        /// UUID chính
        /// </summary>
        [Key]
        public Guid SalaryCompositionID { get; set; }

        /// <summary>
        /// Mã thành phần lương (Unique toàn hệ thống)
        /// </summary>
        [IRequired]
        public string SalaryCompositionCode { get; set; }


        /// <summary>
        /// Tên thành phần lương
        /// </summary>
        [IRequired]
        public string SalaryCompositionName { get; set; }

        /// <summary>
        /// Loại thành phần: Thông tin nhân viên, Chấm công, Khác...
        /// </summary>
        [IRequired]
        public string CompositionType { get; set; }

        /// <summary>
        /// Tính chất: Thu nhập, Khấu trừ, Khác
        /// </summary>
        [IRequired]
        public string NatureType { get; set; }

        /// <summary>
        /// 0: Chịu thuế, 1: Miễn thuế toàn phần, 2: Miễn thuế một phần (Nếu NatureType = Thu nhập)
        /// </summary>
        public int? TaxType { get; set; }

        /// <summary>
        /// 1: Giảm trừ khi tính thuế, 0: Không (Nếu NatureType = Khấu trừ)
        /// </summary>
        public int? IsTaxReduction { get; set; }

        /// <summary>
        /// Công thức hoặc giá trị của Định mức 
        /// </summary>
        public string QuotaFormula { get; set; }

        /// <summary>
        /// Cho phép giá trị tính vượt quá định mức (0: Không, 1: Có)
        /// </summary>
        public int IsAllowOverQuota { get; set; }

        /// <summary>
        /// Kiểu dữ liệu: Số, Tiền tệ, Phần trăm, Chữ, Ngày
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 0: Nhập liệu trực tiếp / Tự động cộng tổng, 1: Tính theo công thức tự đặt
        /// </summary>
        public int ValueCalculationType { get; set; }

        /// <summary>
        /// Phạm vi cộng tổng: Trong cùng đơn vị công tác, Dưới quyền, Thuộc cơ cấu tổ chức
        /// </summary>
        public string AggregationScope { get; set; }

        /// <summary>
        /// Nội dung ô nhập công thức tự đặt khi ValueCalculationType = 1
        /// </summary>
        public string CustomFormula { get; set; }

        /// <summary>
        /// Hiển thị trên phiếu lương (0: Không, 1: Có, 2: Chỉ hiển thị nếu giá trị khác 0)
        /// </summary>
        public int IsVisibleOnPayslip { get; set; }

        /// <summary>
        /// Nguồn tạo: Tự thêm, Hệ thống
        /// </summary>
        public string SourceType { get; set; }

        /// <summary>
        /// Trạng thái: 1: Đang theo dõi, 0: Ngừng theo dõi
        /// </summary>
        public int IsActive { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo (tương ứng CreatedDate trong DB)
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Ngày sửa (tương ứng ModifiedDate trong DB)
        /// Note: kept name pattern similar to other models in project.
        /// </summary>
        public DateTime? ModifieldDate { get; set; }


        [NotMapped]
        public List<string>? OrganizationIdsList { get; set; }

        /// <summary>
        /// Thuộc tính này có tên khớp chính xác với DB (OrganizationIds).
        /// BaseRepository sẽ quét trúng thuộc tính này và sinh ra tham số @v_OrganizationIds kiểu chuỗi.
        /// </summary>
        [NotMapped]
        public string? OrganizationIds
        {
            get
            {
                return OrganizationIdsList != null && OrganizationIdsList.Count > 0
                    ? string.Join(",", OrganizationIdsList)
                    : string.Empty;
            }
        }



        [NotMapped]
        public List<string>? SalaryCompositionIdsList { get; set; }

       
        [NotMapped]
        public string? SalaryCompositionIds
        {
            get
            {
                return SalaryCompositionIdsList != null && SalaryCompositionIdsList.Count > 0
                    ? string.Join(",", SalaryCompositionIdsList )
                    : string.Empty;
            }
        }
    }
}
