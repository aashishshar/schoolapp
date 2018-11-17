namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_DRIVER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_DRIVER()
        {
            MST_ROUTE = new HashSet<MST_ROUTE>();
        }

        [Key]
        public int DriverId { get; set; }

        public int? OrgId { get; set; }

        [StringLength(150)]
        public string DriverName { get; set; }

        [StringLength(15)]
        public string MoNo { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE> MST_ROUTE { get; set; }
    }
}
