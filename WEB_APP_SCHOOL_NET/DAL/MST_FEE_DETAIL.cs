namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_FEE_DETAIL
    {
        [Key]
        public int FeeDetailId { get; set; }

        public int? FeeId { get; set; }

        public int? ClassId { get; set; }

        public decimal? FeeAmount_New { get; set; }

        public decimal? FeeAmount_Old { get; set; }

        public int? Fin_ID { get; set; }

        public string Remark { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        public virtual MST_FEE MST_FEE { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }
    }
}
