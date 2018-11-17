namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ApplicationGroupRole
    {
        [Key]
        public string ApplicationGroupId { get; set; }

        public string ApplicationRoleId { get; set; }

        [StringLength(128)]
        public string ApplicationGroup_Id { get; set; }

        public virtual ApplicationGroup ApplicationGroup { get; set; }
    }
}
