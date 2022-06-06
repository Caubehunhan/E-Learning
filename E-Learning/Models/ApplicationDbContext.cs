using Microsoft.EntityFrameworkCore;

namespace E_Learning.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Permission> Permission { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassSV> ClassSV { get; set; }
        public DbSet<ClassSubjects> ClassSubjects { get; set; }
        public DbSet<CategoryTest> CategoryTest { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Point> Point { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //
            builder.Entity<Point>().HasOne<User>(P => P.SV).WithMany().OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ClassSV>().HasOne<User>(P => P.SV).WithMany().OnDelete(DeleteBehavior.NoAction);
        }

        //
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }   
        }
    } 
}
