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
    internal class GymUserConfigration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {

            builder.Property(X => X.Name).HasMaxLength(50);                
            builder.Property(X => X.Email).HasMaxLength(100); 
            builder.ToTable(Tb =>
                Tb.HasCheckConstraint("CK_Email",
                    "Email LIKE '%_@_%.__%' AND CHARINDEX(' ', Email) = 0")); // Email Validation 
            builder.HasIndex(X => X.Email).IsUnique(); // Email Uniqueness

            builder.Property(X => X.phoneNumber).HasColumnType("VarChar(11)");
            builder.ToTable(Tb =>
                Tb.HasCheckConstraint("CK_PhoneNumber",
                    "LEFT(PhoneNumber, 2) = '01' AND LEN(PhoneNumber) = 11 AND PhoneNumber NOT LIKE '%[^0-9]%'"));// Egyptian Phone Number Validation
            builder.HasIndex(X => X.phoneNumber).IsUnique(); // Phone Number Uniqueness


            builder.OwnsOne(A => A.Address, AddressBuilder =>
            {
                AddressBuilder.Property(A => A.Street).HasColumnType("VarChar(100)");
                AddressBuilder.Property(A => A.City).HasColumnType("VarChar(50)");

            });


        }
    }
}
  