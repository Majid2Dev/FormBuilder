using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Response> DbSet { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Vocabularie> Vocabularies { get; set; }
    }
}
