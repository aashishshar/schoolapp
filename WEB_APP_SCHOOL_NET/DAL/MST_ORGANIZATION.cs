namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_ORGANIZATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_ORGANIZATION()
        {
            MST_CLASS = new HashSet<MST_CLASS>();
            MST_DRIVER = new HashSet<MST_DRIVER>();
            MST_ROUTE_NAME = new HashSet<MST_ROUTE_NAME>();
            MST_STOPNAME = new HashSet<MST_STOPNAME>();
            MST_ROUTE = new HashSet<MST_ROUTE>();
            MST_VEHICLE = new HashSet<MST_VEHICLE>();
        }

        [Key]
        public int Org_Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [MaxLength(5000)]
        public byte[] Image { get; set; }

        public string ImagePath { get; set; }

        public byte? Status { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        public string FaxNumber { get; set; }

        [StringLength(15)]
        public string PanNumber { get; set; }

        [StringLength(100)]
        public string DirectorName { get; set; }

        [StringLength(100)]
        public string PrincipalName { get; set; }

        [StringLength(100)]
        public string ManagerName { get; set; }

        [StringLength(250)]
        public string AffilatedFrom { get; set; }

        [StringLength(50)]
        public string RegistrationNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_CLASS> MST_CLASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_DRIVER> MST_DRIVER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE_NAME> MST_ROUTE_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STOPNAME> MST_STOPNAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE> MST_ROUTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_VEHICLE> MST_VEHICLE { get; set; }
    }
}
