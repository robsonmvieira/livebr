using System.Threading.Tasks;
using LiveBR.CrossCutting.Interfaces;
using LiveBR.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiveBR.Repository.Context
{
    public class LiveBrContext : DbContext, IUnitOfWork
    {
        public LiveBrContext(DbContextOptions<LiveBrContext> options): base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LiveBrContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}