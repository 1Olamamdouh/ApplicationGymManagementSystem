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
    internal class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(X => X.CategoryName)
                .HasColumnType("Varchar(20)");

            builder.HasMany(X => X.Sessions)
                   .WithOne(X => X.Category)
                   .HasForeignKey(X => X.CategoryId);

   


        }
    }
}
