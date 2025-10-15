using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal abstract class BaseEntity
    {
        public int Id { get; set; } // Primary key for the entity
        public DateTime CreatedAt { get; set; } // Automatically set when the entity is created
        public DateTime? UpdatedAt { get; set; } // Nullable to indicate it may not be set initially


    }
}
