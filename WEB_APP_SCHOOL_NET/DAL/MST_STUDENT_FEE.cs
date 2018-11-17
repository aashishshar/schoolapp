namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENT_FEE
    {
        [Key]
        public long StudentFeeId { get; set; }

        public int? Fin_ID { get; set; }

        public int? FeeTermId { get; set; }

        public long? StudentId { get; set; }

        public decimal? FeeAmount_New { get; set; }

        public decimal? FeeAmount_Old { get; set; }

        public bool? IsPaid { get; set; }

        public decimal? DueFee { get; set; }

        public decimal? ConcessionFeeAmt { get; set; }

        [StringLength(500)]
        public string Remark { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual MST_FEE_TERM MST_FEE_TERM { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }
    }
}
