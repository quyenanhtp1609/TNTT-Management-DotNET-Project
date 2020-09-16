namespace TNTT_Management.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChurchModel : DbContext
    {
        public ChurchModel()
            : base("name=ChurchModel")
        {
        }

        public virtual DbSet<CLASS> CLASSes { get; set; }
        public virtual DbSet<LEARNING_GROUP> LEARNING_GROUP { get; set; }
        public virtual DbSet<LEARNING_SUBJECT> LEARNING_SUBJECT { get; set; }
        public virtual DbSet<LOCAL_PARISH> LOCAL_PARISH { get; set; }
        public virtual DbSet<PRIVILEGE> PRIVILEGES { get; set; }
        public virtual DbSet<ROLE> ROLES { get; set; }
        public virtual DbSet<USER_PARISH_ROLE> USER_PARISH_ROLE { get; set; }
        public virtual DbSet<USER_RELATIONSHIP> USER_RELATIONSHIP { get; set; }
        public virtual DbSet<USERLOGIN> USERLOGINs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CLASS>()
                .HasMany(e => e.USERLOGINs)
                .WithOptional(e => e.CLASS)
                .HasForeignKey(e => e.class_id);

            modelBuilder.Entity<LEARNING_SUBJECT>()
                .Property(e => e.school_year)
                .IsUnicode(false);

            modelBuilder.Entity<LEARNING_SUBJECT>()
                .Property(e => e.semester)
                .IsUnicode(false);

            modelBuilder.Entity<LOCAL_PARISH>()
                .HasMany(e => e.LEARNING_GROUP)
                .WithOptional(e => e.LOCAL_PARISH)
                .HasForeignKey(e => e.parishid);

            modelBuilder.Entity<LOCAL_PARISH>()
                .HasMany(e => e.USER_PARISH_ROLE)
                .WithOptional(e => e.LOCAL_PARISH)
                .HasForeignKey(e => e.parishid);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.username)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.userpassword)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.phone_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.father_phone_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.mother_phone_number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .Property(e => e.usercode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERLOGIN>()
                .HasMany(e => e.CLASSes)
                .WithOptional(e => e.USERLOGIN)
                .HasForeignKey(e => e.form_teacher_id);

            modelBuilder.Entity<USERLOGIN>()
                .HasMany(e => e.LEARNING_SUBJECT)
                .WithOptional(e => e.USERLOGIN)
                .HasForeignKey(e => e.teacher_id);

            modelBuilder.Entity<USERLOGIN>()
                .HasMany(e => e.USER_RELATIONSHIP)
                .WithOptional(e => e.USERLOGIN)
                .HasForeignKey(e => e.userfrom_id);

            modelBuilder.Entity<USERLOGIN>()
                .HasMany(e => e.USER_RELATIONSHIP1)
                .WithOptional(e => e.USERLOGIN1)
                .HasForeignKey(e => e.userto_id);
        }
    }
}
