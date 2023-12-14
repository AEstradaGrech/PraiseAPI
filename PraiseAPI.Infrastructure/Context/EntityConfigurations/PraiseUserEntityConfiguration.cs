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
    public class PraiseUserEntityConfiguration : IEntityTypeConfiguration<PraiseUser>
    {
        public void Configure(EntityTypeBuilder<PraiseUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NickName)
                   .HasMaxLength(10)
                   .IsRequired();
            builder.Property(x => x.Email)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.HasIndex(x => x.NickName)
                   .IsUnique();
            builder.HasIndex(x => x.Email)
                   .IsUnique();
            builder.Property(x => x.ModificationDate)
                   .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Password)
                   .IsRequired();
        }
    }
}
