namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_SITE_CONTENT
    {
        [Key]
        public int ContentId { get; set; }

        public int? Org_Id { get; set; }

        [StringLength(50)]
        public string DomainName { get; set; }

        [StringLength(200)]
        public string PageTitle { get; set; }

        [StringLength(500)]
        public string SEOTag { get; set; }

        public byte? ContentName { get; set; }

        [StringLength(200)]
        public string PageContentTitle { get; set; }

        public string PageContentTitleDescriptio { get; set; }

        [StringLength(200)]
        public string ImageTitle { get; set; }

        [Column(TypeName = "image")]
        public byte[] ImageContent { get; set; }

        [StringLength(100)]
        public string VedioPath { get; set; }

        public string PageContent { get; set; }
    }
}
