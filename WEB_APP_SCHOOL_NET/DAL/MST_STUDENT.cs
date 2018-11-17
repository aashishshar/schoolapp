namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MST_STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MST_STUDENT()
        {
            MST_EXAM_REPORT = new HashSet<MST_EXAM_REPORT>();
            MST_STUDENT_ROUTE = new HashSet<MST_STUDENT_ROUTE>();
            MST_STUDENTFEE_RECEIPT = new HashSet<MST_STUDENTFEE_RECEIPT>();
            TRN_STUDENT_SUBJECT = new HashSet<TRN_STUDENT_SUBJECT>();
        }

        [Key]
        public long StudentId { get; set; }

        public int? ClassId { get; set; }

        public long? FormNumber { get; set; }

        [StringLength(20)]
        public string RollNumber { get; set; }

        [StringLength(20)]
        public string SerialNumber { get; set; }

        [StringLength(100)]
        public string StudentName { get; set; }

        [StringLength(100)]
        public string FatherName { get; set; }

        [StringLength(100)]
        public string MotherName { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public string LastSchoolName { get; set; }

        public int? Occupation { get; set; }

        [StringLength(100)]
        public string ResidingSince { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string ReferredBy { get; set; }

        [StringLength(20)]
        public string AadharNumber { get; set; }

        public byte? Session { get; set; }

        [StringLength(15)]
        public string ReferredMobileNumber { get; set; }

        [StringLength(500)]
        public string CorrespondenceAddress { get; set; }

        [StringLength(500)]
        public string PermanentAddress { get; set; }

        [StringLength(150)]
        public string Village_Town { get; set; }

        [StringLength(15)]
        public string ContactNumber { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(15)]
        public string Nationality { get; set; }

        public int? Fin_ID { get; set; }

        [StringLength(15)]
        public string WhatsAppNo { get; set; }

        public int? SectionId { get; set; }

        public long? CityId { get; set; }

        public short? CasteType { get; set; }

        public int? ReligionId { get; set; }

        public int? CasteId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public long? StateId { get; set; }

        public bool? IsTransport { get; set; }

        [StringLength(100)]
        public string ImageUrl { get; set; }

        public virtual MST_CASTE MST_CASTE { get; set; }

        public virtual MST_CITY MST_CITY { get; set; }

        public virtual MST_CLASS MST_CLASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_EXAM_REPORT> MST_EXAM_REPORT { get; set; }

        public virtual MST_FINYEAR MST_FINYEAR { get; set; }

        public virtual MST_OCCUPATION MST_OCCUPATION { get; set; }

        public virtual MST_RELIGION MST_RELIGION { get; set; }

        public virtual MST_SECTION MST_SECTION { get; set; }

        public virtual MST_STATE MST_STATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENT_ROUTE> MST_STUDENT_ROUTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MST_STUDENTFEE_RECEIPT> MST_STUDENTFEE_RECEIPT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRN_STUDENT_SUBJECT> TRN_STUDENT_SUBJECT { get; set; }
    }
}
