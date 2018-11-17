namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_SUB_SUBJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_SUB_SUBJECT()
        {
            MST_EXAM = new HashSet<MST_EXAM>();
        }

        [Key]
        public int SubSubjectId { get; set; }

        public int? SubjectId { get; set; }

        [StringLength(50)]
        public string subSubjectName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_EXAM> MST_EXAM { get; set; }

        public virtual MST_SUBJECT MST_SUBJECT { get; set; }
    }
}
