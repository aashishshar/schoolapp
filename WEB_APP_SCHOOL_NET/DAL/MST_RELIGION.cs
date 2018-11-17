namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_RELIGION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_RELIGION()
        {
            MST_CASTE = new HashSet<MST_CASTE>();
            MST_STUDENT = new HashSet<MST_STUDENT>();
        }

        [Key]
        public int ReligionId { get; set; }

        public string ReligionName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_CASTE> MST_CASTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT> MST_STUDENT { get; set; }
    }
}
