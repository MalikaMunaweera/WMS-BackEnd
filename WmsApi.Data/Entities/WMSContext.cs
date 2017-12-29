using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WmsApi.Data.Entities
{
    public partial class WMSContext : DbContext
    {
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectAllocations> ProjectAllocations { get; set; }
        public virtual DbSet<UserStory> UserStory { get; set; }
        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<WorkflowActivity> WorkflowActivity { get; set; }
        public virtual DbSet<WorkflowActivityExecution> WorkflowActivityExecution { get; set; }
        public virtual DbSet<WorkflowActivityField> WorkflowActivityField { get; set; }
        public virtual DbSet<WorkflowActivityFieldType> WorkflowActivityFieldType { get; set; }
        public virtual DbSet<WorkflowActivityType> WorkflowActivityType { get; set; }
        public virtual DbSet<WorkflowExecution> WorkflowExecution { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=WMS;Integrated Security=False;User ID=sa;Password=38340677");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DesignationNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Designation)
                    .HasConstraintName("FK_Employee_Designation");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectAllocations>(entity =>
            {
                entity.HasKey(e => new { e.Project, e.Employee });

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithMany(p => p.ProjectAllocations)
                    .HasForeignKey(d => d.Employee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectAllocations_Employee");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.ProjectAllocations)
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProjectAllocations_Project");
            });

            modelBuilder.Entity<UserStory>(entity =>
            {
                entity.Property(e => e.AcceptanceCriteria)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Activity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastModified).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.UserStoryCreatorNavigation)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_UserStory_Employee");

                entity.HasOne(d => d.ModifiedByNavigation)
                    .WithMany(p => p.UserStoryModifiedByNavigation)
                    .HasForeignKey(d => d.ModifiedBy)
                    .HasConstraintName("FK_UserStory_Employee2");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.UserStory)
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("FK_UserStory_Project");
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Version });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Workflow)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_Workflow_Employee");
            });

            modelBuilder.Entity<WorkflowActivity>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.WorkflowActivity)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowActivityType_WorkflowActivityFieldType");

                entity.HasOne(d => d.WorkflowNavigation)
                    .WithMany(p => p.WorkflowActivity)
                    .HasForeignKey(d => new { d.Workflow, d.WorkflowVersion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowActivity_Workflow");
            });

            modelBuilder.Entity<WorkflowActivityExecution>(entity =>
            {
                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.OutCome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.WorkflowExecutionNavigation)
                    .WithMany(p => p.WorkflowActivityExecution)
                    .HasForeignKey(d => d.WorkflowExecution)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowActivityExecution_WorkflowExecution");
            });

            modelBuilder.Entity<WorkflowActivityField>(entity =>
            {
                entity.Property(e => e.Value)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityNavigation)
                    .WithMany(p => p.WorkflowActivityField)
                    .HasForeignKey(d => d.Activity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_WorkflowActivity");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.WorkflowActivityField)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_WorkflowActivityType");
            });

            modelBuilder.Entity<WorkflowActivityFieldType>(entity =>
            {
                entity.Property(e => e.DataType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ActivityTypeNavigation)
                    .WithMany(p => p.WorkflowActivityFieldType)
                    .HasForeignKey(d => d.ActivityType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowActivityFieldType_WorkflowActivityType");
            });

            modelBuilder.Entity<WorkflowActivityType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkflowExecution>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.InitiatedByNavigation)
                    .WithMany(p => p.WorkflowExecution)
                    .HasForeignKey(d => d.InitiatedBy)
                    .HasConstraintName("FK_WorkflowExecution_Employee");

                entity.HasOne(d => d.UserStoryNavigation)
                    .WithMany(p => p.WorkflowExecution)
                    .HasForeignKey(d => d.UserStory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowExecution_UserStory");

                entity.HasOne(d => d.WorkflowNavigation)
                    .WithMany(p => p.WorkflowExecution)
                    .HasForeignKey(d => new { d.Workflow, d.WorkflowVersion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowExecution_Workflow1");
            });
        }
    }
}
