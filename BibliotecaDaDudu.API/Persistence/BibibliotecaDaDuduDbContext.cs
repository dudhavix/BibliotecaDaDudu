using BibliotecaDaDudu.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace BibliotecaDaDudu.API.Persistence
{
    public class BibibliotecaDaDuduDbContext : DbContext
    {
        public BibibliotecaDaDuduDbContext(DbContextOptions<BibibliotecaDaDuduDbContext> options): base(options)
        {
           
        }

        public DbSet<MangaEntity> Mangas { get; set; }
        public DbSet<VolumeEntity> Volumes { get; set; }
        public DbSet<ImagemEntity> Imagens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ImagemEntity>(entity =>
            {
                entity.HasKey(imagem => imagem.Id);
                entity.Property(imagem => imagem.Texto).IsRequired().HasColumnType("text");
                entity.Property(imagem => imagem.Nome).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
                entity.Property(imagem => imagem.CreatedAt).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.HasMany<MangaEntity>().WithOne().HasForeignKey(manga => manga.CapaId).IsRequired();
                entity.HasMany<VolumeEntity>().WithOne().HasForeignKey(manga => manga.CapaId).IsRequired();
            });

            builder.Entity<MangaEntity>(entity =>
            {
                entity.HasKey(manga => manga.Id);
                entity.Property(manga => manga.Titulo).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
                entity.Property(manga => manga.Editora).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
                entity.Property(manga => manga.Autor).IsRequired().HasMaxLength(50).HasColumnType("varchar(50)");
                entity.Property(manga => manga.TotalVolumes).IsRequired().HasColumnType("int");
                entity.Property(manga => manga.Sinopse).IsRequired(false).HasMaxLength(500).HasColumnType("varchar(500)");
                entity.Property(manga => manga.Concluido).IsRequired().HasColumnType("bit").HasDefaultValue(false);
                entity.Property(manga => manga.Avaliacao).IsRequired().HasColumnType("decimal").HasDefaultValue(0);
                entity.Property(manga => manga.StatusLeitura).IsRequired();
                entity.HasMany(manga => manga.Volumes).WithOne().HasForeignKey(volume => volume.MangaId);
                entity.Property(manga => manga.Ativo).IsRequired().HasColumnType("bit").HasDefaultValue(true);
                entity.Property(manga => manga.CreatedAt).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()");
            });

            builder.Entity<VolumeEntity>(entity =>
            {
                entity.HasKey(volume => volume.Id);
                entity.Property(volume => volume.Numero).IsRequired().HasColumnType("int");
                entity.Property(volume => volume.Avaliacao).IsRequired().HasColumnType("decimal").HasDefaultValue(0);
                entity.Property(volume => volume.StatusLeitura).IsRequired();
                entity.Property(volume => volume.Sinopse).IsRequired(false).HasMaxLength(500).HasColumnType("varchar(500)");
                entity.Property(volume => volume.StatusCompra).IsRequired();
                entity.Property(volume => volume.MangaId).IsRequired();
                entity.Property(volume => volume.CreatedAt).IsRequired().HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(volume => volume.CapaId).IsRequired();
            });        
        }
    }
}
