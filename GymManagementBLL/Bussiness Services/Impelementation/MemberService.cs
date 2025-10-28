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

        public bool CreateMember(CreateMemberViewModel createMember)
        {
            //Email or Phone not exist
            var memberByEmail = _memberRepository.GetAll(M => M.Email == createMember.Email).Any();
            var memberByPhone = _memberRepository.GetAll(M => M.phoneNumber == createMember.PhoneNumber).Any();

            if (memberByEmail || memberByPhone) return false;

            //CreateMemberViewModel=> Member 

            var newMember = new Member
            {
                Name = createMember.Name,
                Email = createMember.Email,
                phoneNumber = createMember.PhoneNumber,
                DateOfBirth = createMember.DateOfBirth,
                Address = new Address
                {
                    BildingNumber = createMember.BuildingNumber.ToString(),
                    City = createMember.City,
                    Street = createMember.street,

                },
                HealthRecord = new HealthRecord
                {
                    Height = createMember.HealthRecord.Height,
                    Weight = createMember.HealthRecord.Weight,
                    BloodType = createMember.HealthRecord.Booltype,
                    Note = createMember.HealthRecord.Notes,
                },
            };

           return _memberRepository.Add(newMember) > 0;
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