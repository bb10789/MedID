using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AzureAPI.Model
{
    public partial class MedidContext : DbContext
    {
        public MedidContext()
        {
        }

        public MedidContext(DbContextOptions<MedidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserId> UserId { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {

        //        optionsBuilder.UseSqlServer("Server=tcp:medid.database.windows.net,1433;Initial Catalog=medid;Persist Security Info=False;User ID=bb10789;Password=Gomedid!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Interaction>(entity =>
        //    {
        //        entity.Property(e => e.InteractionId).ValueGeneratedNever();

        //        entity.HasOne(d => d.Id1Navigation)
        //            .WithMany(p => p.InteractionId1Navigation)
        //            .HasForeignKey(d => d.Id1)
        //            .HasConstraintName("FK__Interaction__id1__71D1E811");

        //        entity.HasOne(d => d.Id2Navigation)
        //            .WithMany(p => p.InteractionId2Navigation)
        //            .HasForeignKey(d => d.Id2)
        //            .HasConstraintName("FK__Interaction__id2__72C60C4A");
        //    });
        
        //    modelBuilder.Entity<UserId>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.Fname).IsUnicode(false);

        //        entity.Property(e => e.Lname).IsUnicode(false);

        //        entity.Property(e => e.Location).IsUnicode(false);

        //        entity.Property(e => e.Password).IsUnicode(false);

        //        entity.Property(e => e.Phone).IsUnicode(false);

        //        entity.Property(e => e.Email).IsUnicode(false);

        //        entity.Property(e => e.Salt).IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    
}
