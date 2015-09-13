﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusicStore.Domain.Models.Mapping
{
    public partial class AspNetUserMap : EntityTypeConfiguration<AspNetUser>
    {
        partial void OtherMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .IsRequired()
				.HasMaxLength(128)
				.HasColumnName("Id");

			this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(256)
				.HasColumnName("UserName")
				.HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") {IsClustered = false, IsUnique = true}));

            // Table & Column Mappings
			//Needn't', it is already in file generated by Mapping.tt
            //this.ToTable("AspNetUsers");

			this.Property(t => t.PasswordHash)
				.HasColumnName("PasswordHash");

			this.Property(t => t.SecurityStamp)
				.HasColumnName("SecurityStamp");

			this.Property(t => t.Email)
				.HasMaxLength(256)
				.HasColumnName("Email");

			this.Property(t => t.EmailConfirmed)
				.IsRequired()
				.HasColumnName("EmailConfirmed");

			this.Property(t => t.PhoneNumber)
				.HasColumnName("PhoneNumber");

			this.Property(t => t.PhoneNumberConfirmed)
				.IsRequired()
				.HasColumnName("PhoneNumberConfirmed");

			this.Property(t => t.TwoFactorEnabled)
				.IsRequired()
				.HasColumnName("TwoFactorEnabled");

			this.Property(t => t.LockoutEndDateUtc)
				.HasColumnName("LockoutEndDateUtc");

			this.Property(t => t.LockoutEnabled)
				.IsRequired()
				.HasColumnName("LockoutEnabled");

			this.Property(t => t.AccessFailedCount)
				.IsRequired()
				.HasColumnName("AccessFailedCount");

			// Relationships
            this.HasMany(t => t.Roles)
                .WithRequired()
                .HasForeignKey(ur => ur.UserId);

			this.HasMany(t => t.Claims)
                .WithRequired()
                .HasForeignKey(uc => uc.UserId);

			this.HasMany(t => t.Logins)
                .WithRequired()
                .HasForeignKey(ul => ul.UserId);

        }
    }
}