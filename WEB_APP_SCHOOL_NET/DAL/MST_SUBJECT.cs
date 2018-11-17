namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_SUBJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_SUBJECT()
        {
            MST_SUB_SUBJECT = new HashSet<MST_SUB_SUBJECT>();
            TRN_STUDENT_SUBJECT = new HashSet<TRN_STUDENT_SUBJECT>();
        }

        [Key]
        public int SubjectId { get; set; }

        [StringLength(100)]
        public string SubjectName { get; set; }

        public int? ClassId { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(128)]
        public string UpdatedBy { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_SUB_SUBJECT> MST_SUB_SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_SUBJECT> TRN_STUDENT_SUBJECT { get; set; }
    }
}
