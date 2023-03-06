using System.Diagnostics.Metrics;
using System;
using AirBNB.Models;
using AirBNB.Models.Reviews;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AirBNB.Data
{
	public class ApplicationDbContext : IdentityDbContext<AplicationUser>
	{
		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<City> Cities { get; set; }
		public virtual DbSet<Region> Regions { get; set; }
		public virtual DbSet<Property> Properties { get; set; }
		public virtual DbSet<PropertyUnavailableDay> PropertyUnavailableDays { get; set; }
		public virtual DbSet<Amenity> Amenities { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<House_Rule> HouseRules { get; set; }
		public virtual DbSet<PropertyImage> PropertyImages { get; set; }
		public virtual DbSet<Review> Reviews { get; set; }
		public virtual DbSet<Reservation> Reservations { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<PropertyUnavailableDay>()
				.HasKey(p => new { p.PropertyId, p.UnavailableDay });
			base.OnModelCreating(builder);
			builder.Entity<IdentityUser>()
				.Ignore(i => i.PhoneNumber)
				.Ignore(i => i.EmailConfirmed)
				.Ignore(i => i.AccessFailedCount)
				.Ignore(i => i.LockoutEnabled)
				.Ignore(i => i.ConcurrencyStamp)
				.Ignore(i => i.LockoutEnabled)
                .Ignore(i => i.TwoFactorEnabled)
				.Ignore(i => i.PhoneNumberConfirmed)
                .Ignore(i => i.UserName)
                .Ignore(i => i.NormalizedUserName)
                .Ignore(i => i.LockoutEnd)
                .Ignore(i => i.SecurityStamp)

                ;
        }
	}
}