namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENT_ATTENDANCE
    {
        [Key]
        public long StudentAttendId { get; set; }

        public long? StudentId { get; set; }

        public int? SectionId { get; set; }

        public bool? IsPresent { get; set; }

        [StringLength(5)]
        public string Attand_Status { get; set; }

        public DateTime? PresentDate { get; set; }

        [StringLength(10)]
        public string PresentDay { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual MST_SECTION MST_SECTION { get; set; }
    }
}
