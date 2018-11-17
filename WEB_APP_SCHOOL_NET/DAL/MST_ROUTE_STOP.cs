namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_ROUTE_STOP
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? StopId { get; set; }

        public int? StudentRouteId { get; set; }

        public virtual MST_ROUTE MST_ROUTE { get; set; }

        public virtual MST_STOPNAME MST_STOPNAME { get; set; }
    }
}
