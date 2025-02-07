using Microsoft.EntityFrameworkCore;
using ModelosEvaluativos.Models;

namespace ModelosEvaluativos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EvaluationModel> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EvaluationModel>().ToTable("modelo_evaluativo");
        }
    }
}