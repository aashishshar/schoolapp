namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENTFEE_RECEIPT
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string ReceiptNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SubmitDate { get; set; }

        public int FeeTermId { get; set; }

        public byte? SubmitType { get; set; }

        [StringLength(100)]
        public string TransactionNumber { get; set; }

        public decimal? TotalFee { get; set; }

        public long? StudentId { get; set; }

        public int? Fin_Id { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }

        public virtual MST_FEE_TERM MST_FEE_TERM { get; set; }

        public virtual MST_STUDENT MST_STUDENT { get; set; }
    }
}
