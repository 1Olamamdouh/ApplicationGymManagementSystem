using GymManagementBLL.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Bussiness_Services.Interfaces
{
    public interface IMemberService
    {

        IEnumerable<MemberViewModel> GetAllMembers(); // Retrieve all members

    }
}
