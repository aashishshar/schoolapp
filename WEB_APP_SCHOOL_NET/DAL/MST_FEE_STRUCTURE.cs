namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_FEE_STRUCTURE
    {
        [Key]
        public int FeeStructureId { get; set; }

        public int? Fin_ID { get; set; }

        public int? FeeId { get; set; }

        public int? ClassId { get; set; }

        public byte? FeeDuration { get; set; }

        public int? TermCount { get; set; }

        public decimal? Fee_New_Amt { get; set; }

        public decimal? Total_New_Amt { get; set; }

        public decimal? Fee_Old_Amt { get; set; }

        public decimal? Total_Old_Amt { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        public virtual MST_FEE MST_FEE { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }
    }
}
