namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_CONTENT
    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(50)]
        public string DomainName { get; set; }

        [StringLength(100)]
        public string TitleName { get; set; }

        public string PageName { get; set; }

        public bool? Status { get; set; }
    }
}
