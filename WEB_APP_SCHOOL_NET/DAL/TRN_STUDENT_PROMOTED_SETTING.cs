namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRN_STUDENT_PROMOTED_SETTING
    {
        [Key]
        public int PromotedId { get; set; }

        public int? PromotedClassFromId { get; set; }

        public int? PromotedSectionFromId { get; set; }

        public int? PromotedClassToId { get; set; }

        public int? PromotedSectionToId { get; set; }

        public int? PromotedFinYearIDFrom { get; set; }

        public int? PromotedFinYearIDTo { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        public virtual MST_CLASS MST_CLASS1 { get; set; }

        public virtual MST_SECTION MST_SECTION { get; set; }

        public virtual MST_SECTION MST_SECTION1 { get; set; }
    }
}
