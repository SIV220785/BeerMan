namespace BeerMan.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BeermanContext : DbContext
    {
        static BeermanContext()
        {

        }

        public BeermanContext()
            : base("name=BeerManConnection")
        {
        }



        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DeliveryOrder> Deliveries { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Party> Parties { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasOptional(w => w.Wallet)
                .WithRequired(a => a.AspNetUsers);

            modelBuilder.Entity<Wallet>()
                .HasMany(e => e.Transactions)
                .WithOptional(e => e.Wallet);

            modelBuilder.Entity<Order>()
                .HasMany(c => c.Foods)
                .WithMany(p => p.Orders)
                .Map(m =>
                {
                    m.ToTable("OrdersFood");
                    m.MapLeftKey("OrderId");
                    m.MapRightKey("FoodId");
                });
        }
    }
}
