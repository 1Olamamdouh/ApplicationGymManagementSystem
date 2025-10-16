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
    internal class MemberConfigration : GymUserConfigration<Member>, IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.Property(X => X.CreatedAt)
                .HasColumnName("JoinDate") // Rename CreatedAt to JoinDate
                .HasDefaultValue("GETDATE()"); // Default Value

            base.Configure(builder); // Call base configuration for GymUserConfigration


        }
    }
}
