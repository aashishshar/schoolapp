namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_FINYEAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_FINYEAR()
        {
            MST_EXAM = new HashSet<MST_EXAM>();
            MST_FEE_DETAIL = new HashSet<MST_FEE_DETAIL>();
            MST_FEE_STRUCTURE = new HashSet<MST_FEE_STRUCTURE>();
            MST_STUDENT_FEE = new HashSet<MST_STUDENT_FEE>();
            MST_STUDENT = new HashSet<MST_STUDENT>();
            MST_STUDENTFEE_RECEIPT = new HashSet<MST_STUDENTFEE_RECEIPT>();
        }

        [Key]
        public int Fin_ID { get; set; }

        [StringLength(10)]
        public string Finyear { get; set; }

        [StringLength(15)]
        public string Finyear_Format { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_EXAM> MST_EXAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_DETAIL> MST_FEE_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_STRUCTURE> MST_FEE_STRUCTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT_FEE> MST_STUDENT_FEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENTFEE_RECEIPT> MST_STUDENTFEE_RECEIPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT> MST_STUDENT { get; set; }
    }
}
