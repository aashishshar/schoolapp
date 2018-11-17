namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_FEE_TERM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_FEE_TERM()
        {
            MST_STUDENT_FEE = new HashSet<MST_STUDENT_FEE>();
            MST_STUDENTFEE_RECEIPT = new HashSet<MST_STUDENTFEE_RECEIPT>();
        }

        [Key]
        public int TermId { get; set; }

        public byte? FeeTerm { get; set; }

        public int? FeeId { get; set; }

        public virtual MST_FEE MST_FEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT_FEE> MST_STUDENT_FEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENTFEE_RECEIPT> MST_STUDENTFEE_RECEIPT { get; set; }
    }
}
