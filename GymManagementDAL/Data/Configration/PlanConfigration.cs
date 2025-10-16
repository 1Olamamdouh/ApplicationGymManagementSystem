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
    internal class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(X => X.Name).HasColumnType("Varchar(50)");
            builder.Property(X => X.Description).HasColumnType("Varchar(200)");
            builder.Property(X => X.Price).HasPrecision(18, 2);

            builder.ToTable(Tb =>
                Tb.HasCheckConstraint("DurationDaysConstraint", "DurationDays BETWEEN 1 AND 356")); // Example constraint: Duration must be between 1 and 356 days
        }
    }
}
