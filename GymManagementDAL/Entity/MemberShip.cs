using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    public class MemberShip:BaseEntity
    {

        // Join Table for Many-to-Many relationship between Member and Plan
        public int MemberId { get; set; } // Foreign key to Member
        public Member Member { get; set; }


        public int PlanId { get; set; } // Foreign key to Plan
        public Plan Plan { get; set; }
        public DateTime EndDate { get; set; }

        //Derived Attribute or Computed Attribute
        public string Status 
        {
            get
            {
                if (EndDate >= DateTime.Now)
                {
                    return "Expired";
                }
                else
                {
                    return "Active";
                }
            }
                
        }


    }
}
