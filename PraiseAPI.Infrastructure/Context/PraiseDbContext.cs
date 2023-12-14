using Microsoft.EntityFrameworkCore;
using PraiseAPI.Domain.Entities;
using PraiseAPI.Domain.Repositories;
using PraiseAPI.Infrastructure.Context.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Context
{
    public class PraiseDbContext : DbContext, IUnitOfWork
    {
        public PraiseDbContext(DbContextOptions<PraiseDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            builder.ApplyConfiguration<PraiseUser>(new PraiseUserEntityConfiguration());
            builder.ApplyConfiguration<PraiseCharacter>(new CharactersEntityConfiguration());
            builder.ApplyConfiguration<CharStats>(new CharStatsEntityConfiguration());
            builder.ApplyConfiguration<Role>(new RolesEntityConfiguration());
            builder.ApplyConfiguration<UserRole>(new UserRolesEntityConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
            => await SaveChangesAsync(cancellationToken) > 0;

        public bool SaveEntities(CancellationToken cancellationToken = default)
            => SaveChanges() > 0;

        public DbSet<PraiseUser> Users { get; set; }
        public DbSet<PraiseCharacter> Characters { get; set; }
        public DbSet<CharStats> CharStats { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
