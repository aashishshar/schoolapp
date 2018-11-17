namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_ROUTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_ROUTE()
        {
            MST_ROUTE_STOP = new HashSet<MST_ROUTE_STOP>();
            MST_STUDENT_ROUTE = new HashSet<MST_STUDENT_ROUTE>();
        }

        [Key]
        public int StudentRouteId { get; set; }

        public int? Org_Id { get; set; }

        public int? RouteId { get; set; }

        public int? VehicleId { get; set; }

        public int? DriverId { get; set; }

        public int? StopId { get; set; }

        public decimal? RoutePriceAmt { get; set; }

        public virtual MST_DRIVER MST_DRIVER { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        public virtual MST_STOPNAME MST_STOPNAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_ROUTE_STOP> MST_ROUTE_STOP { get; set; }

        public virtual MST_ROUTE_NAME MST_ROUTE_NAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT_ROUTE> MST_STUDENT_ROUTE { get; set; }

        public virtual MST_VEHICLE MST_VEHICLE { get; set; }
    }
}
