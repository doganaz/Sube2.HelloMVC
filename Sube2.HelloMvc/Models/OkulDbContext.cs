using Microsoft.EntityFrameworkCore;

namespace Sube2.HelloMvc.Models
{
    public class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<OgrenciDers> OgrenciDersler { get; set; }

        public OkulDbContext(DbContextOptions<OkulDbContext> options)
            : base(options)
        {
        }

        public OkulDbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.;Integrated Security=true;Initial Catalog=OkulDbSube2MVC;user=sa;password=abc123;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();

            modelBuilder.Entity<Ders>().ToTable("tblDersler");
            modelBuilder.Entity<Ders>().Property(d => d.Dersad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ders>().Property(d => d.Kredi).IsRequired();

            modelBuilder.Entity<OgrenciDers>()
                .HasKey(od => new { od.Ogrenciid, od.Dersid });

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Ogrenci)
                .WithMany(o => o.OgrenciDersler)
                .HasForeignKey(od => od.Ogrenciid);

            modelBuilder.Entity<OgrenciDers>()
                .HasOne(od => od.Ders)
                .WithMany(d => d.OgrenciDersler)
                .HasForeignKey(od => od.Dersid);
        }
    }
}
