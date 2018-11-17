namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_EXAM_REPORT
    {
        public int ID { get; set; }

        public int ExamId { get; set; }

        public byte ObtainedMarks { get; set; }

        public long StudentId { get; set; }

        public virtual MST_EXAM MST_EXAM { get; set; }

        public virtual MST_STUDENT MST_STUDENT { get; set; }
    }
}
