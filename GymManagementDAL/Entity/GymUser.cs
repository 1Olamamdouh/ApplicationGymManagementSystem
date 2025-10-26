using GymManagementDAL.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    public class GymUser : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public DateOnly DateOfBirth { get; set; } // Using DateOnly for date without time
        public Gender Gender { get; set; } // Changed to string to accommodate
        public Address Address { get; set; } // Composed of an Address object
    }

    [Owned]
   public  class Address
    {
        public string BildingNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; } 

    }
}
