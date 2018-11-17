namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_CLASS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_CLASS()
        {
            MST_FEE_DETAIL = new HashSet<MST_FEE_DETAIL>();
            MST_FEE_STRUCTURE = new HashSet<MST_FEE_STRUCTURE>();
            MST_SECTION = new HashSet<MST_SECTION>();
            MST_STUDENT = new HashSet<MST_STUDENT>();
            MST_SUBJECT = new HashSet<MST_SUBJECT>();
            TRN_STUDENT_PROMOTEDFrom = new HashSet<TRN_STUDENT_PROMOTED_SETTING>();
            TRN_STUDENT_PROMOTEDTo = new HashSet<TRN_STUDENT_PROMOTED_SETTING>();
        }

        [Key]
        public int ClassId { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? Org_Id { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public virtual MST_ORGANIZATION MST_ORGANIZATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_DETAIL> MST_FEE_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_STRUCTURE> MST_FEE_STRUCTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_SECTION> MST_SECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT> MST_STUDENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_SUBJECT> MST_SUBJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_PROMOTED_SETTING> TRN_STUDENT_PROMOTEDFrom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_PROMOTED_SETTING> TRN_STUDENT_PROMOTEDTo { get; set; }
    }
}
