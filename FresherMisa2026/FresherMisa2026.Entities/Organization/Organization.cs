using FresherMisa2026.Entities.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace FresherMisa2026.Entities.Organization
{
    [ConfigTable("Pa_Organization", false, "OrganizationCode")]
    public class Organization : BaseModel
    {
        [Key]
        public Guid OrganizationID { get; set; }

        public string OrganizationCode { get; set; }

        public string OrganizationName { get; set; }

        public Guid? ParentId { get; set; }

        public int IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifieldDate { get; set; }
    }
}