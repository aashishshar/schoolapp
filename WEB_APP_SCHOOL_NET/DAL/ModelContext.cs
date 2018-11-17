namespace WEB_APP_SCHOOL_NET.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<MST_CASTE> MST_CASTE { get; set; }
        public virtual DbSet<MST_CITY> MST_CITY { get; set; }
        public virtual DbSet<MST_CLASS> MST_CLASS { get; set; }
        public virtual DbSet<MST_CONTENT> MST_CONTENT { get; set; }
        public virtual DbSet<MST_DRIVER> MST_DRIVER { get; set; }
        public virtual DbSet<MST_EXAM> MST_EXAM { get; set; }
        public virtual DbSet<MST_EXAM_REPORT> MST_EXAM_REPORT { get; set; }
        public virtual DbSet<MST_FEE> MST_FEE { get; set; }
        public virtual DbSet<MST_FEE_DETAIL> MST_FEE_DETAIL { get; set; }
        public virtual DbSet<MST_FEE_STRUCTURE> MST_FEE_STRUCTURE { get; set; }
        public virtual DbSet<MST_FEE_TERM> MST_FEE_TERM { get; set; }
        public virtual DbSet<MST_FINYEAR> MST_FINYEAR { get; set; }
        public virtual DbSet<MST_OCCUPATION> MST_OCCUPATION { get; set; }
        public virtual DbSet<MST_ORGANIZATION> MST_ORGANIZATION { get; set; }
        public virtual DbSet<MST_RELIGION> MST_RELIGION { get; set; }
        public virtual DbSet<MST_ROUTE> MST_ROUTE { get; set; }
        public virtual DbSet<MST_ROUTE_NAME> MST_ROUTE_NAME { get; set; }
        public virtual DbSet<MST_ROUTE_STOP> MST_ROUTE_STOP { get; set; }
        public virtual DbSet<MST_SECTION> MST_SECTION { get; set; }
        public virtual DbSet<MST_SITE_CONTENT> MST_SITE_CONTENT { get; set; }
        public virtual DbSet<MST_STATE> MST_STATE { get; set; }
        public virtual DbSet<MST_STOPNAME> MST_STOPNAME { get; set; }
        public virtual DbSet<MST_STUDENT> MST_STUDENT { get; set; }
        public virtual DbSet<MST_STUDENT_ATTENDANCE> MST_STUDENT_ATTENDANCE { get; set; }
        public virtual DbSet<MST_STUDENT_FEE> MST_STUDENT_FEE { get; set; }
        public virtual DbSet<MST_STUDENT_ROUTE> MST_STUDENT_ROUTE { get; set; }
        public virtual DbSet<MST_STUDENTFEE_RECEIPT> MST_STUDENTFEE_RECEIPT { get; set; }
        public virtual DbSet<MST_SUB_SUBJECT> MST_SUB_SUBJECT { get; set; }
        public virtual DbSet<MST_SUBJECT> MST_SUBJECT { get; set; }
        public virtual DbSet<MST_VEHICLE> MST_VEHICLE { get; set; }
        public virtual DbSet<TRN_STUDENT_SUBJECT> TRN_STUDENT_SUBJECT { get; set; }
        public virtual DbSet<TRN_STUDENT_PROMOTED_SETTING> TRN_STUDENT_PROMOTED { get; set; }
        public virtual DbSet<MST_STUDENT_PROMOTED> MST_STUDENT_PROMOTED { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MST_CASTE>()
                .HasMany(e => e.MST_STUDENT)
                .WithOptional(e => e.MST_CASTE)
                .WillCascadeOnDelete();
            modelBuilder.Entity<MST_STUDENT_PROMOTED>()
               .Property(e => e.CreatedBy)
               .IsUnicode(false);
            modelBuilder.Entity<MST_CITY>()
                .HasMany(e => e.MST_STUDENT)
                .WithOptional(e => e.MST_CITY)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.MST_FEE_DETAIL)
                .WithOptional(e => e.MST_CLASS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.MST_FEE_STRUCTURE)
                .WithOptional(e => e.MST_CLASS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.MST_SECTION)
                .WithOptional(e => e.MST_CLASS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.MST_STUDENT)
                .WithOptional(e => e.MST_CLASS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.MST_SUBJECT)
                .WithOptional(e => e.MST_CLASS)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_CONTENT>()
                .Property(e => e.DomainName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_CONTENT>()
                .Property(e => e.TitleName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_DRIVER>()
                .Property(e => e.DriverName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_DRIVER>()
                .Property(e => e.MoNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_DRIVER>()
                .HasMany(e => e.MST_ROUTE)
                .WithOptional(e => e.MST_DRIVER)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FEE>()
                .HasMany(e => e.MST_FEE_DETAIL)
                .WithOptional(e => e.MST_FEE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FEE>()
                .HasMany(e => e.MST_FEE_STRUCTURE)
                .WithOptional(e => e.MST_FEE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FEE>()
                .HasMany(e => e.MST_FEE_TERM)
                .WithOptional(e => e.MST_FEE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FEE_TERM>()
                .HasMany(e => e.MST_STUDENT_FEE)
                .WithOptional(e => e.MST_FEE_TERM)
                .HasForeignKey(e => e.FeeTermId)
                .WillCascadeOnDelete();


            modelBuilder.Entity<MST_FEE_TERM>()
                .HasMany(e => e.MST_STUDENTFEE_RECEIPT)
                .WithRequired(e => e.MST_FEE_TERM)
                .HasForeignKey(e => e.FeeTermId);

            modelBuilder.Entity<MST_FINYEAR>()
                .HasMany(e => e.MST_FEE_DETAIL)
                .WithOptional(e => e.MST_FINYEAR)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FINYEAR>()
               .HasMany(e => e.MST_STUDENTFEE_RECEIPT)
               .WithOptional(e => e.MST_FINYEAR)
               .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FINYEAR>()
                .HasMany(e => e.MST_FEE_STRUCTURE)
                .WithOptional(e => e.MST_FINYEAR)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_FINYEAR>()
                .HasMany(e => e.MST_STUDENT_FEE)
                .WithOptional(e => e.MST_FINYEAR)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_OCCUPATION>()
                .HasMany(e => e.MST_STUDENT)
                .WithOptional(e => e.MST_OCCUPATION)
                .HasForeignKey(e => e.Occupation)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);

            modelBuilder.Entity<MST_ORGANIZATION>()
                .HasMany(e => e.MST_CLASS)
                .WithOptional(e => e.MST_ORGANIZATION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .HasMany(e => e.MST_DRIVER)
                .WithOptional(e => e.MST_ORGANIZATION)
                .HasForeignKey(e => e.OrgId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .HasMany(e => e.MST_ROUTE_NAME)
                .WithOptional(e => e.MST_ORGANIZATION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .HasMany(e => e.MST_STOPNAME)
                .WithOptional(e => e.MST_ORGANIZATION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_ORGANIZATION>()
                .HasMany(e => e.MST_VEHICLE)
                .WithOptional(e => e.MST_ORGANIZATION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_RELIGION>()
                .HasMany(e => e.MST_CASTE)
                .WithRequired(e => e.MST_RELIGION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MST_RELIGION>()
                .HasMany(e => e.MST_STUDENT)
                .WithOptional(e => e.MST_RELIGION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_SECTION>()
                .HasMany(e => e.MST_STUDENT_ATTENDANCE)
                .WithOptional(e => e.MST_SECTION)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_SITE_CONTENT>()
                .Property(e => e.DomainName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_STOPNAME>()
                .HasMany(e => e.MST_ROUTE_STOP)
                .WithOptional(e => e.MST_STOPNAME)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_STUDENT>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MST_STUDENT>()
                .Property(e => e.ImageUrl)
                .IsUnicode(false);

            modelBuilder.Entity<MST_STUDENT>()
                .HasMany(e => e.MST_STUDENT_ROUTE)
                .WithOptional(e => e.MST_STUDENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_STUDENT>()
                .HasMany(e => e.MST_STUDENTFEE_RECEIPT)
                .WithOptional(e => e.MST_STUDENT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_STUDENT_ATTENDANCE>()
                .Property(e => e.Attand_Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MST_STUDENT_ATTENDANCE>()
                .Property(e => e.PresentDay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MST_STUDENTFEE_RECEIPT>()
                .Property(e => e.ReceiptNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MST_STUDENTFEE_RECEIPT>()
                .Property(e => e.TransactionNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MST_SUB_SUBJECT>()
                .Property(e => e.subSubjectName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_SUBJECT>()
                .HasMany(e => e.MST_SUB_SUBJECT)
                .WithOptional(e => e.MST_SUBJECT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_SUBJECT>()
                .HasMany(e => e.TRN_STUDENT_SUBJECT)
                .WithOptional(e => e.MST_SUBJECT)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.RegnNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.RegnOwnerName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.ChassisNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.RegnAuthority)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.EngineNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.Color)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.MakersClass)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.InsuranceNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.InsuranceBy)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.PolutionNo)
                .IsUnicode(false);

            modelBuilder.Entity<MST_VEHICLE>()
                .Property(e => e.PollutionBy)
                .IsUnicode(false);

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.TRN_STUDENT_PROMOTEDFrom)
                .WithOptional(e => e.MST_CLASS)
                .HasForeignKey(e => e.PromotedClassFromId);

            modelBuilder.Entity<MST_CLASS>()
                .HasMany(e => e.TRN_STUDENT_PROMOTEDTo)
                .WithOptional(e => e.MST_CLASS1)
                .HasForeignKey(e => e.PromotedClassToId);

            modelBuilder.Entity<MST_SECTION>()
               .HasMany(e => e.TRN_STUDENT_PROMOTEDFrom)
               .WithOptional(e => e.MST_SECTION)
               .HasForeignKey(e => e.PromotedSectionFromId);

            modelBuilder.Entity<MST_SECTION>()
                .HasMany(e => e.TRN_STUDENT_PROMOTEDTo)
                .WithOptional(e => e.MST_SECTION1)
                .HasForeignKey(e => e.PromotedSectionToId);
        }
    }
}
