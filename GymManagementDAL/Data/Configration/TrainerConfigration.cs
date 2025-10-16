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
    internal class TrainerConfigration:GymUserConfigration<Trainer>, IEntityTypeConfiguration<Trainer>
    {
     public new void Configure(EntityTypeBuilder<Trainer> builder)
        {

            builder.Property(X => X.CreatedAt)
                 .HasColumnName("HireDate") // Rename column to HireDate
                 .HasDefaultValueSql("GetDate()"); // Default value to current date


            base.Configure(builder); // Call base configuration for GymUserConfigration properties
        }




    }
}
