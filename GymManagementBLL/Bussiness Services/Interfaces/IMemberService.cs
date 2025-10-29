using GymManagementBLL.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Bussiness_Services.Interfaces
{
    internal interface IMemberService
    {

        IEnumerable<MemberViewModel> GetAllMembers(); // Retrieve all members
        bool CreateMember(CreateMemberViewModel createMember); // Create a new member
        MemberViewModel? GetMemberDitails(int memberId); // Get details of a specific member by ID

    }
}
