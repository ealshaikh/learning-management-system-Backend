using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Adminuserlogin> Adminuserlogins { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Coursesection> Coursesections { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<Plancourse> Plancourses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Studentassessment> Studentassessments { get; set; } = null!;
        public virtual DbSet<Studentenrollment> Studentenrollments { get; set; } = null!;
        public virtual DbSet<Studentuserlogin> Studentuserlogins { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Teacheruserlogin> Teacheruserlogins { get; set; } = null!;
        public virtual DbSet<Usercourse> Usercourses { get; set; } = null!;
        public virtual DbSet<Usersection> Usersections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=MindMaster;Password=1234;Data Source=localhost:1521/xepdb1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MINDMASTER")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.Adminid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADMINID");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");
            });

            modelBuilder.Entity<Adminuserlogin>(entity =>
            {
                entity.ToTable("ADMINUSERLOGIN");

                entity.HasIndex(e => e.Adminid, "SYS_C009533")
                    .IsUnique();

                entity.Property(e => e.Adminuserloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ADMINUSERLOGINID");

                entity.Property(e => e.Adminid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ADMINID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID")
                    .HasDefaultValueSql("1 ");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Adminuserlogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009535");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.HasIndex(e => new { e.Sectionid, e.Studentid, e.Attendancedate }, "UQ_ATTENDANCE")
                    .IsUnique();

                entity.Property(e => e.Attendanceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDANCEID");

                entity.Property(e => e.Attendancedate)
                    .HasColumnType("DATE")
                    .HasColumnName("ATTENDANCEDATE");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Status)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009688");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009689");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("CARD");

                entity.Property(e => e.Cardid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARDID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.CardCvv)
                    .HasPrecision(3)
                    .HasColumnName("CARD_CVV");

                entity.Property(e => e.CardNumber)
                    .HasPrecision(16)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.CardholderName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDER_NAME");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRY_DATE");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("CERTIFICATE");

                entity.HasIndex(e => new { e.Studentid, e.Planid }, "UQ_UNIQUECERTIFICATE")
                    .IsUnique();

                entity.Property(e => e.Certificateid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CERTIFICATEID");

                entity.Property(e => e.Certificatedate)
                    .HasColumnType("DATE")
                    .HasColumnName("CERTIFICATEDATE");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009589");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009588");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Messeage)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSEAGE");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Coverimage)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("COVERIMAGE");
            });

            modelBuilder.Entity<Coursesection>(entity =>
            {
                entity.ToTable("COURSESECTION");

                entity.Property(e => e.Coursesectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSESECTIONID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Coursesections)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009573");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("EXAM");

                entity.HasIndex(e => e.Courseid, "SYS_C009553")
                    .IsUnique();

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Endtime)
                    .HasPrecision(6)
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Examdate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXAMDATE");

                entity.Property(e => e.Mark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'100' ");

                entity.Property(e => e.Starttime)
                    .HasPrecision(6)
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Orderid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDERID");

                entity.Property(e => e.Orderdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDERDATE");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending'\n");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Totalprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTALPRICE");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009694");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009693");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Plan");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLANID");

                entity.Property(e => e.Coverimage)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("COVERIMAGE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Plandescription)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("PLANDESCRIPTION");

                entity.Property(e => e.Planname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PLANNAME");

                entity.Property(e => e.Planprice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANPRICE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");
            });

            modelBuilder.Entity<Plancourse>(entity =>
            {
                entity.ToTable("PLANCOURSE");

                entity.HasIndex(e => new { e.Planid, e.Courseid }, "UQ_PLANCOURSE")
                    .IsUnique();

                entity.Property(e => e.Plancourseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLANCOURSEID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Ordernumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDERNUMBER");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Plancourses)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009568");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("SECTION");

                entity.HasIndex(e => e.Teacherid, "SYS_C009542")
                    .IsUnique();

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Endtime)
                    .HasPrecision(6)
                    .HasColumnName("ENDTIME");

                entity.Property(e => e.Material)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("MATERIAL");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.Property(e => e.Sectioncapacity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONCAPACITY");

                entity.Property(e => e.SectionlecLink)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONLEC_LINK");

                entity.Property(e => e.Sectionname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONNAME");

                entity.Property(e => e.Sectionno)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONNO");

                entity.Property(e => e.Sectionstatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SECTIONSTATUS");

                entity.Property(e => e.Starttime)
                    .HasPrecision(6)
                    .HasColumnName("STARTTIME");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHERID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009543");

                entity.HasOne(d => d.Teacher)
                    .WithOne(p => p.Section)
                    .HasForeignKey<Section>(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009545");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Dob)
                    .HasColumnType("DATE")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Phoneno)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("PHONENO");

                entity.Property(e => e.Profileimage)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEIMAGE");

                entity.Property(e => e.Studentfname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STUDENTFNAME");

                entity.Property(e => e.Studentlname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STUDENTLNAME");
            });

            modelBuilder.Entity<Studentassessment>(entity =>
            {
                entity.ToTable("STUDENTASSESSMENT");

                entity.Property(e => e.Studentassessmentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTASSESSMENTID");

                entity.Property(e => e.Comment)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Studentassessments)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009564");
            });

            modelBuilder.Entity<Studentenrollment>(entity =>
            {
                entity.HasKey(e => e.Enrollmentid)
                    .HasName("SYS_C009598");

                entity.ToTable("STUDENTENROLLMENT");

                entity.HasIndex(e => e.Studentid, "SYS_C009599")
                    .IsUnique();

                entity.Property(e => e.Enrollmentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ENROLLMENTID");

                entity.Property(e => e.Approvalstatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APPROVALSTATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Enrollmentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENROLLMENTDATE");

                entity.Property(e => e.Planid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLANID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Studentenrollments)
                    .HasForeignKey(d => d.Planid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009601");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Studentenrollment)
                    .HasForeignKey<Studentenrollment>(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009600");
            });

            modelBuilder.Entity<Studentuserlogin>(entity =>
            {
                entity.ToTable("STUDENTUSERLOGIN");

                entity.HasIndex(e => e.Studentid, "SYS_C009514")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UNIQUE_EMAIL_CONSTRAINT")
                    .IsUnique();

                entity.Property(e => e.Studentuserloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTUSERLOGINID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID")
                    .HasDefaultValueSql("3 ");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Studentuserlogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009516");

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Studentuserlogin)
                    .HasForeignKey<Studentuserlogin>(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009515");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("TEACHER");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TEACHERID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Dob)
                    .HasColumnType("DATE")
                    .HasColumnName("DOB");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Phoneno)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("PHONENO");

                entity.Property(e => e.Profileimage)
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEIMAGE");

                entity.Property(e => e.Teacherfname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEACHERFNAME");

                entity.Property(e => e.Teacherlname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TEACHERLNAME");
            });

            modelBuilder.Entity<Teacheruserlogin>(entity =>
            {
                entity.ToTable("TEACHERUSERLOGIN");

                entity.HasIndex(e => e.Teacherid, "SYS_C009521")
                    .IsUnique();

                entity.Property(e => e.Teacheruserloginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TEACHERUSERLOGINID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Password ");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID")
                    .HasDefaultValueSql("2 ");

                entity.Property(e => e.Teacherid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TEACHERID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Teacheruserlogins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009523");

                entity.HasOne(d => d.Teacher)
                    .WithOne(p => p.Teacheruserlogin)
                    .HasForeignKey<Teacheruserlogin>(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009522");
            });

            modelBuilder.Entity<Usercourse>(entity =>
            {
                entity.ToTable("USERCOURSE");

                entity.HasIndex(e => new { e.Courseid, e.Studentid }, "UQ_USERCOURSE")
                    .IsUnique();

                entity.Property(e => e.Usercourseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERCOURSEID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Examid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAMID");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Studentgrade)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTGRADE");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Usercourses)
                    .HasForeignKey(d => d.Examid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009584");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Usercourses)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009583");
            });

            modelBuilder.Entity<Usersection>(entity =>
            {
                entity.ToTable("USERSECTION");

                entity.HasIndex(e => new { e.Sectionid, e.Studentid }, "UQ_USERSECTION")
                    .IsUnique();

                entity.Property(e => e.Usersectionid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERSECTIONID");

                entity.Property(e => e.Sectionid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Usersections)
                    .HasForeignKey(d => d.Sectionid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009577");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Usersections)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("SYS_C009578");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
