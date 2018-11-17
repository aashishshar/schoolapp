namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_VEHICLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_VEHICLE()
        {
            MST_ROUTE = new HashSet<MST_ROUTE>();
        }

        [Key]
        public int VehicleId { get; set; }

        public int? Org_Id { get; set; }

        [StringLength(20)]
        public string RegnNo { get; set; }

        [StringLength(50)]
        public string RegnOwnerName { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        public DateTime? MFGDate { get; set; }

        [StringLength(100)]
        public string ChassisNo { get; set; }

        [StringLength(100)]
        public string RegnAuthority { get; set; }

        public DateTime? RegnDate { get; set; }

        public DateTime? RegnValidUpTo { get; set; }

        public byte? FuelUsed { get; set; }

        [StringLength(50)]
        public string EngineNo { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        [StringLength(20)]
        public string MakersClass { get; set; }

        public short? SeatingCapacity { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        public DateTime? FitnessValidity { get; set; }

        public byte? VehicleType { get; set; }

        [StringLength(50)]
        public string InsuranceNo { get; set; }

        [StringLength(50)]
        public string InsuranceBy { get; set; }

        public DateTime? InsuranceStartDate { get; set; }

        public DateTime? InsuranceValidUpToDate { get; set; }

        [StringLength(50)]
        public string PolutionNo { get; set; }

        [StringLength(50)]
        public string PollutionBy { get; set; }

        public DateTime? PollutionStartDate { get; set; }

        public DateTime? PollutionEndDate { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE> MST_ROUTE { get; set; }
    }
}
