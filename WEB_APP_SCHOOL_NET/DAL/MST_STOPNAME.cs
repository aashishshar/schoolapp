namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STOPNAME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_STOPNAME()
        {
            MST_ROUTE = new HashSet<MST_ROUTE>();
            MST_ROUTE_STOP = new HashSet<MST_ROUTE_STOP>();
        }

        [Key]
        public int StopId { get; set; }

        public int? RouteId { get; set; }

        public int? Org_Id { get; set; }

        [StringLength(100)]
        public string StopName { get; set; }

        public TimeSpan? PickUpTiming { get; set; }

        public TimeSpan? DropTiming { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE> MST_ROUTE { get; set; }

        public virtual MST_ROUTE_NAME MST_ROUTE_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE_STOP> MST_ROUTE_STOP { get; set; }
    }
}
