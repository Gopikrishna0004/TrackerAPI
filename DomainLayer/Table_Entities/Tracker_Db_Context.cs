using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DomainLayer.Table_Entities
{
    public partial class Tracker_Db_Context : DbContext
    {
        public Tracker_Db_Context()
        {
        }

        public Tracker_Db_Context(DbContextOptions<Tracker_Db_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<MenusList> MenusList { get; set; }
        public virtual DbSet<MenusRolesMap> MenusRolesMap { get; set; }
        public virtual DbSet<TblErrorLogs> TblErrorLogs { get; set; }
        public virtual DbSet<TblMasterIssuePriorities> TblMasterIssuePriorities { get; set; }
        public virtual DbSet<TblMasterIssueStatuses> TblMasterIssueStatuses { get; set; }
        public virtual DbSet<TblProjectIssues> TblProjectIssues { get; set; }
        public virtual DbSet<TblProjects> TblProjects { get; set; }
        public virtual DbSet<TblWebApiLogs> TblWebApiLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-D2BL0S1\\SQLEXPRESS;Initial Catalog=Tracker_DB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<MenusList>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK_Table_1");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.MenuController)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuCreatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuCreatedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MenuDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.MenuUpdaetdOn).HasColumnType("smalldatetime");

                entity.Property(e => e.MenuUpdatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.MenuUrl)
                    .HasColumnName("MenuURL")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenusRolesMap>(entity =>
            {
                entity.HasKey(e => e.MenuRoleId)
                    .HasName("PK_MenuRolesMap");

                entity.Property(e => e.MenuRoleId).HasColumnName("MenuRoleID");

                entity.Property(e => e.RoleId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RoleMapUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleMapUpdatedOn).HasColumnType("smalldatetime");

                entity.Property(e => e.RoleMappedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleMappedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenusRolesMap)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuRolesMap_MenusList");
            });

            modelBuilder.Entity<TblErrorLogs>(entity =>
            {
                entity.HasKey(e => e.ErrorId);

                entity.ToTable("TBL_ErrorLogs");

                entity.Property(e => e.ErrorId).HasColumnName("ErrorID");

                entity.Property(e => e.ErrorDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ErrorMessage)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMasterIssuePriorities>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.ToTable("TBL_MasterIssuePriorities");

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.PriorityActiveOrNot)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PriorityCreatedBy).HasMaxLength(50);

                entity.Property(e => e.PriorityCreatedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PriorityDescription).HasMaxLength(500);

                entity.Property(e => e.PriorityName).HasMaxLength(50);

                entity.Property(e => e.PriorityUpdatedBy).HasMaxLength(50);

                entity.Property(e => e.PriorityUpdatedOn).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TblMasterIssueStatuses>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("TBL_MasterIssueStatuses");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusActiveOrNot)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusCreatedBy).HasMaxLength(50);

                entity.Property(e => e.StatusCreatedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StatusDescription).HasMaxLength(500);

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StatusUpdatedBy).HasMaxLength(50);

                entity.Property(e => e.StatusUpdatedOn).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TblProjectIssues>(entity =>
            {
                entity.HasKey(e => e.IssueId);

                entity.ToTable("TBL_ProjectIssues");

                entity.Property(e => e.IssueId).HasColumnName("IssueID");

                entity.Property(e => e.IssueAssignee)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IssueComments).HasMaxLength(500);

                entity.Property(e => e.IssueCreatedBy).HasMaxLength(100);

                entity.Property(e => e.IssueCreatedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IssueDescription).HasMaxLength(500);

                entity.Property(e => e.IssueEstimatedTime)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IssueHeading).HasMaxLength(250);

                entity.Property(e => e.IssueModule).HasMaxLength(500);

                entity.Property(e => e.IssueReporter)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IssueStatusId).HasDefaultValueSql("((10))");

                entity.Property(e => e.IssueTimeStarts)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IssueType).HasMaxLength(100);

                entity.Property(e => e.IssueUpdatedBy).HasMaxLength(100);

                entity.Property(e => e.IssueUpdatedOn).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TblProjects>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("TBL_Projects");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectCategory)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProjectCreatedBy).HasMaxLength(250);

                entity.Property(e => e.ProjectCreatedOn)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProjectDescription).HasMaxLength(500);

                entity.Property(e => e.ProjectKey).HasMaxLength(5);

                entity.Property(e => e.ProjectLogo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectManager).HasMaxLength(250);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProjectTeamLead).HasMaxLength(250);

                entity.Property(e => e.ProjectType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProjectUpdatedBy).HasMaxLength(250);

                entity.Property(e => e.ProjectUpdatedOn).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<TblWebApiLogs>(entity =>
            {
                entity.ToTable("TBL_WebApiLogs");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
