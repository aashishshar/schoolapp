namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENT_PROMOTED
    {
        [Key]
        public long PromotedId { get; set; }

        public int? Fin_ID { get; set; }

        public int? ClassId { get; set; }

        public int? SectionId { get; set; }

        public long? StudentId { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreatedBy { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }

        public virtual MST_SECTION MST_SECTION { get; set; }

        public virtual MST_STUDENT MST_STUDENT { get; set; }
    }
}
