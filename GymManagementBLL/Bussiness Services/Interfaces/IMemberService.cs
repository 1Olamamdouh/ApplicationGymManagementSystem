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
        HealthRecordViewModel? GetHealthRecordDetalis(int memberId); // Get health record of a specific member by ID 
        MemberToUpdataViewModel? GetMemberDetalisToUpata(int memberId); // Get member data for update
        bool UpdataMember(int memberId, MemberToUpdataViewModel memberToUpdata); // Update member information
    }
}
