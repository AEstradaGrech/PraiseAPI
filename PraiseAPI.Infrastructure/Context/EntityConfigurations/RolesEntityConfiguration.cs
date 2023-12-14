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
    public class RolesEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(10)
                .IsRequired();
            builder.Property(x => x.DisplayName)
               .HasMaxLength(20)
               .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();
        }
    }
}
