namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_ROUTE_NAME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_ROUTE_NAME()
        {
            MST_ROUTE = new HashSet<MST_ROUTE>();
            MST_STOPNAME = new HashSet<MST_STOPNAME>();
        }

        [Key]
        public int RouteId { get; set; }

        [StringLength(150)]
        public string RouteName { get; set; }

        public int? Org_Id { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE> MST_ROUTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STOPNAME> MST_STOPNAME { get; set; }
    }
}
