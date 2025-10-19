using GymManagementDAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Data.Configration
{
    internal class HealthRecordConfigration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
           builder.ToTable("Members").HasKey(X => X.Id); // Primary Key , Inherited from BaseEntity

            builder.HasOne<Member>() //fluent API for one-to-one relationship
                .WithOne(X => X.HealthRecord)
                .HasForeignKey<HealthRecord>(X => X.Id); // MemberId is FK in HealthRecord table


            builder.Ignore(X => X.CreatedAt); // Ignore CreatedAt property

        }
    }
}
