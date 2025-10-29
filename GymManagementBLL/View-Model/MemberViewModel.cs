using GymManagementDAL.Entity;
using GymManagementDAL.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.View_Model
{
    internal class MemberViewModel
    {
        public int MemberId { get; set; }
        public string Name { get; set; }= null!;
        public string Email { get; set; }= null!; 
        public string PhoneNumber { get; set; } = null!; 
        public string? Photo { get; set; }
        public string Gender { get; set; } = null!; // Changed to string to accommodate
        public string? Plan { get; set; } 
        public string? DateOfBirth { get; set; }    
        public string? Address { get; set; }
        public string? MemberShipStartDate { get; set; }
        public string? MemberShipEndDate { get; set; }
    }
}
