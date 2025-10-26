using GymManagementDAL.Data.Context;
using GymManagementDAL.Entity;
using GymManagementDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.implementation
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly GymDbContext _dbContext; //Private Referance 

        // Implement member repository operations here

        //private readonly  GymDbContext _dbContext = new GymDbContext();

        //ASK CLR To inject Object From GymDb Context in the run time 
        public MemberRepository(GymDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public int AddMember(Member member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();
        }
        public int DeleteMember(int memberId)
        { 
            _dbContext.Members.Remove(GetMemberById(memberId)!);
            return _dbContext.SaveChanges();
        }
        public IEnumerable<Member> GetAllMembers() => _dbContext.Members.ToList();

        public Member? GetMemberById(int memberId) => _dbContext.Members.Find(memberId);

        public int UpdateMember(Member member)
        {
            _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}
