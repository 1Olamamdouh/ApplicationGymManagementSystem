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
        private readonly IGenericRepository<MemberShip> _memberShipRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IGenericRepository<HealthRecord> _healthRecordRepository;

        //Ask CLR to inject object from class implement interface IGenericRepository<Member>
        public MemberService(IGenericRepository<Member> MemberRepository, 
                             IGenericRepository<MemberShip> MemberShipRepository, 
                             IPlanRepository planRepository, 
                             IGenericRepository<HealthRecord> HealthRecordRepository)
        {  
            _memberRepository = MemberRepository;
            _memberShipRepository = MemberShipRepository;
            _planRepository = planRepository;
            _healthRecordRepository = HealthRecordRepository;
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

        public MemberViewModel? GetMemberDitails(int memberId)
        {
            var member = _memberRepository.GetById(memberId);
            if (member is null) return null;

            var memberViewModel = new MemberViewModel
            {
                Email = member.Email,
                Name = member.Name,
                PhoneNumber = member.phoneNumber,
                Photo = member.photo,
                Gender = member.Gender.ToString(),
                DateOfBirth = member.DateOfBirth.ToShortDateString(),
                Address = $"{member.Address.BildingNumber}, " +
                          $"{member.Address.Street}, " +
                          $"{member.Address.City}",
            };

            var MemberShip = _memberShipRepository
                .GetAll(M => M.MemberId == memberId && M.Status == "Active")
                .FirstOrDefault();

            if (MemberShip is not null)
            {
                memberViewModel.MemberShipStartDate = MemberShip.CreatedAt.ToShortDateString();
                memberViewModel.MemberShipEndDate = MemberShip.EndDate.ToShortDateString(); 
            
                var plan = _planRepository.GetPlanById(MemberShip.PlanId);
                memberViewModel.Plan = plan?.Name;  
            }
            return memberViewModel;
        }
    
        public HealthRecordViewModel GetHealthRecordDetalis(int memberId)
        {
            var memberHealthReorder = _healthRecordRepository.GetById(memberId);               

            if (memberHealthReorder is null) return null!;

            var healthRecordViewModel = new HealthRecordViewModel
            {
                Height = memberHealthReorder.Height,
                Weight = memberHealthReorder.Weight,
                Booltype = memberHealthReorder.BloodType,
                Notes = memberHealthReorder.Note,
            };

            return healthRecordViewModel;
        }

        public MemberToUpdataViewModel? GetMemberDetalisToUpata(int memberId)
        {
            var member = _memberRepository.GetById(memberId);
            if (member is null) return null;

            var memberToUpdataViewModel = new MemberToUpdataViewModel
            {
                Name = member.Name,
                Photo = member.photo,
                PhoneNumber = member.phoneNumber,
                Email = member.Email,
                BuildingNumber = int.Parse( member.Address.BildingNumber),
                City = member.Address.City,
                street = member.Address.Street,
            };
            return memberToUpdataViewModel;

        }

        public bool UpdataMember(int memberId, MemberToUpdataViewModel memberToUpdata)
        {
            try
            {
                var EmallExists = _memberRepository
                    .GetAll(M => M.Email == memberToUpdata.Email && M.Id != memberId).Any();
                var PhoneExists = _memberRepository
                    .GetAll(M => M.phoneNumber == memberToUpdata.PhoneNumber && M.Id != memberId).Any();

                if (EmallExists || PhoneExists) return false;

                var member = _memberRepository.GetById(memberId);
                if (member is null) return false;

                member.phoneNumber = memberToUpdata.PhoneNumber;
                member.Email = memberToUpdata.Email;
                member.Address.BildingNumber = memberToUpdata.BuildingNumber.ToString();
                member.Address.City = memberToUpdata.City;
                member.Address.Street = memberToUpdata.street;
                member.UpdatedAt = DateTime.Now;

                return _memberRepository.Update(member) > 0; //return true if update is successful

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}