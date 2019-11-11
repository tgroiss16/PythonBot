using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectArcher_Backend.Models
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(125);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.ExternalContact).HasColumnName("external_contact");

                entity.Property(e => e.InternalContact).HasColumnName("internal_contact");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.PhoneNumberLandline)
                    .HasColumnName("phone_number_landline")
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumberMobile)
                    .HasColumnName("phone_number_mobile")
                    .HasMaxLength(100);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(12);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(125);

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender");

                entity.Property(e => e.InternalContact).HasColumnName("internal_contact");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.PhoneNumberLandline).HasColumnName("phone_number_landline");

                entity.Property(e => e.PhoneNumberMobile).HasColumnName("phone_number_mobile");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.TitlePostfix)
                    .HasColumnName("title_postfix")
                    .HasMaxLength(100);

                entity.Property(e => e.TitlePrefix)
                    .HasColumnName("title_prefix")
                    .HasMaxLength(100);

                entity.HasOne(d => d.CompanyNavigation)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkey_companyId");
            });
        }
    }
}
