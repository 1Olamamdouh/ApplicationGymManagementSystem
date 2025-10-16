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
    internal class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {

            builder.ToTable(Tb =>
            {

                Tb.HasCheckConstraint("Capacity_Constraint", "Capacity between 1 and 25");
                Tb.HasCheckConstraint("End_Constraint", "EndTime > StartTime");


            }
            );
        }
    }
}
