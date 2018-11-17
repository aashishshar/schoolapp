namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_OCCUPATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_OCCUPATION()
        {
            MST_STUDENT = new HashSet<MST_STUDENT>();
        }

        [Key]
        public int Occupation_ID { get; set; }

        [StringLength(100)]
        public string OccupationName { get; set; }

        public byte? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT> MST_STUDENT { get; set; }
    }
}
