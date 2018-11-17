namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_SECTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_SECTION()
        {
            MST_STUDENT_ATTENDANCE = new HashSet<MST_STUDENT_ATTENDANCE>();
            MST_STUDENT = new HashSet<MST_STUDENT>();
            TRN_STUDENT_PROMOTEDFrom = new HashSet<TRN_STUDENT_PROMOTED_SETTING>();
            TRN_STUDENT_PROMOTEDTo = new HashSet<TRN_STUDENT_PROMOTED_SETTING>();
        }

        [Key]
        public int SectionId { get; set; }

        [StringLength(50)]
        public string SectionName { get; set; }

        public int? ClassId { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT_ATTENDANCE> MST_STUDENT_ATTENDANCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT> MST_STUDENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_PROMOTED_SETTING> TRN_STUDENT_PROMOTEDFrom { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_PROMOTED_SETTING> TRN_STUDENT_PROMOTEDTo { get; set; }
    }
}
