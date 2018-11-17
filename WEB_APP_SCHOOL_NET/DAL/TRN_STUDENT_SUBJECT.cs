namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_STUDENT_SUBJECT
    {
        [Key]
        public int Rel_Id { get; set; }

        public int? SubjectId { get; set; }

        public long? StudentId { get; set; }

        public virtual MST_STUDENT MST_STUDENT { get; set; }

        public virtual MST_SUBJECT MST_SUBJECT { get; set; }
    }
}
