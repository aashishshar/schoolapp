namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_FEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_FEE()
        {
            MST_FEE_DETAIL = new HashSet<MST_FEE_DETAIL>();
            MST_FEE_STRUCTURE = new HashSet<MST_FEE_STRUCTURE>();
            MST_FEE_TERM = new HashSet<MST_FEE_TERM>();
        }

        [Key]
        public int FeeId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? Org_ID { get; set; }

        [StringLength(200)]
        public string FeeName { get; set; }

        public byte? FeeDuration { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_DETAIL> MST_FEE_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_STRUCTURE> MST_FEE_STRUCTURE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_FEE_TERM> MST_FEE_TERM { get; set; }
    }
}
