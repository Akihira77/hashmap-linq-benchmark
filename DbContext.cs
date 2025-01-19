using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Entity> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=localhost;Database=Test;User Id=SA;Password=A&VeryStrongPassword!@#;Pooling=True;MultipleActiveResultSets=True; Integrated Security=False; Trusted_Connection=False;TrustServerCertificate=True;");
            // .UseSeeding((context, _) =>
            // {
            //     var entities = new List<Entity>();
            //     for (int k = 1; k <= 1_000_000; k++)
            //     {
            //         var id = Guid.NewGuid();
            //         var entity = new Entity
            //         {
            //             Id = id,
            //             DistrictCode = "District-" + k,
            //             SegmentBusinessName = "Segment Business Name " + k,
            //             ParameterDescName = "Formula " + k,
            //             CustomerCode = "Customer-" + k,
            //             IsForContract = k % 2 == 0 ? "Yes" : "No",
            //             IsForAccrue = k % 2 == 1 ? "Yes" : "No",
            //             CreatedAt = DateTime.Now,
            //         };
            //
            //         entities.Add(entity);
            //     }
            //
            //     context.Set<Entity>().AddRange(entities);
            //     context.SaveChanges();
            // });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entity>()
            .HasIndex(e => new { e.DistrictCode, e.CustomerCode, e.SegmentBusinessName, e.ParameterDescName })
            .IsUnique(true);
    }
}

