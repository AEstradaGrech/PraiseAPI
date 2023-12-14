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
    internal class CharactersEntityConfiguration : IEntityTypeConfiguration<PraiseCharacter>
    {
        public void Configure(EntityTypeBuilder<PraiseCharacter> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User)
                   .WithMany(u => u.Characters)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.Navigation(x => x.User)
                  .IsRequired();
            builder.Property(x => x.Name)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.HasIndex(x => x.Name)
                   .IsUnique();
            builder.Property(x => x.CreationDate)
                   .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.ModificationDate)
                   .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CurrentGameZone)
                   .HasDefaultValue("NeverConnected");
            builder.Property(x => x.DeleteDate)
                   .HasDefaultValue(null);
        }
    }
}
