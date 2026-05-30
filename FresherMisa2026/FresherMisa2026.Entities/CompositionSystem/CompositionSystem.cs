using FresherMisa2026.Entities.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace FresherMisa2026.Entities.CompositionSystem
{
    [ConfigTable("Pa_Salary_Composition_System", false, "SalaryCompositionCode")]
    public class CompositionSystem : BaseModel
    {
        [Key]
        public Guid SalaryCompositionSystemID { get; set; }

        public string SalaryCompositionCode { get; set; }

        public string SalaryCompositionName { get; set; }

        public string CompositionType { get; set; }

        public string NatureType { get; set; }

        public string Formula { get; set; }


        public int IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifieldDate { get; set; }
    }
}