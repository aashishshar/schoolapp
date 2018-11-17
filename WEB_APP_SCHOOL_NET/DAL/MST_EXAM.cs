namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_EXAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_EXAM()
        {
            MST_EXAM_REPORT = new HashSet<MST_EXAM_REPORT>();
        }

        [Key]
        public int ExamId { get; set; }

        public int? SubjectId { get; set; }

        public int? SubSubjectId { get; set; }

        public byte MaximumMarks { get; set; }

        public byte PassingMarks { get; set; }

        public int Fin_ID { get; set; }

        public byte ExamTypeId { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }

        public virtual MST_SUB_SUBJECT MST_SUB_SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_EXAM_REPORT> MST_EXAM_REPORT { get; set; }
    }
}
