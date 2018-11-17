namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENT_ROUTE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssignRouteId { get; set; }

        public long? StudentId { get; set; }

        public int? StudentRouteId { get; set; }

        public decimal? StudentRouteFeeAmt { get; set; }

        public virtual MST_ROUTE MST_ROUTE { get; set; }

        public virtual MST_STUDENT MST_STUDENT { get; set; }
    }
}
