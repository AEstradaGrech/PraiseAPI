using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PraiseAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraiseAPI.Infrastructure.Context.EntityConfigurations
{
    internal class CharStatsEntityConfiguration : IEntityTypeConfiguration<CharStats>
    {
        public void Configure(EntityTypeBuilder<CharStats> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Character)
                   .WithMany(c => c.CharStats)
                   .HasForeignKey(x => x.CharacterId);
            builder.HasIndex(x => new { x.CharacterId, x.LevelUpDate })
                   .IsUnique();
            builder.Property(x => x.CreationDate)
                   .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModificationDate)
                   .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.LevelUpDate)
                   .HasDefaultValue(null);
            builder.Navigation(x => x.Character)
                   .IsRequired();
            builder.Property(x => x.Level)
                   .HasDefaultValue(1);
            builder.Property(x => x.CharExp)
                   .HasDefaultValue(.0f);
            builder.Property(x => x.LevelUpExp)
                   .HasDefaultValue(.0f);
        }
    }
}
