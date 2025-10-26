using GymManagementBLL.Bussiness_Services.Interfaces;
using GymManagementBLL.View_Model;
using GymManagementDAL.Entity;
using GymManagementDAL.Entity.Enums;
using GymManagementDAL.Repository.implementation;
using GymManagementDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Bussiness_Services.Impelementation
{
    internal class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;

        //Ask CLR to inject object from class implement interface IGenericRepository<Member>
        public MemberService(IGenericRepository<Member> MemberRepository) {
            _memberRepository = MemberRepository;
        }
        public IEnumerable<MemberViewModel> GetAllMembers()
        {

            var members = _memberRepository.GetAll();

            if (members is null || !members.Any()) return [];

            #region manual mapping first way
            //var listMemberViewModels = new List<MemberViewModel>();

            //foreach (var Member in members)
            //{
            //    var memberViewModel = new MemberViewModel
            //    {
            //        MemberId = Member.Id,
            //        Email = Member.Email,
            //        Name = Member.Name,
            //        PhoneNumber = Member.phoneNumber,
            //        Photo = Member.photo,
            //        Gender = Member.Gender.ToString()
            //    };
            //    listMemberViewModels.Add(memberViewModel);
            //}
            //return listMemberViewModels;

            #endregion

            #region manual mapping second way
            var listMemberViewModels = members.Select(M => new MemberViewModel
            {
                MemberId = M.Id,
                Email = M.Email,
                Name = M.Name,
                PhoneNumber = M.phoneNumber,
                Photo = M.photo,
                Gender = M.Gender.ToString(),
            });
            return listMemberViewModels;
            #endregion
        } 
    }
} 