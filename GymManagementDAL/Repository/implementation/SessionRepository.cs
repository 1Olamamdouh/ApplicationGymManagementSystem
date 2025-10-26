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
    internal class SessionRepository : ISessionRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public SessionRepository(GymDbContext dbContext) {
            _dbContext = dbContext;
        }
        public int AddSession(Session session)
        {
            _dbContext.Sessions.Add(session);
            return _dbContext.SaveChanges();
        }

        public int DeleteSession(Session session)
        {
            _dbContext.Sessions.Remove(GetSession(session.Id)!);
            return _dbContext.SaveChanges();
        }

       public  IEnumerable<Session> GetAllSessions() => _dbContext.Sessions.ToList();

        public Session? GetSession(int id) => _dbContext.Sessions.Find(id);

      public int UpdateSession(Session session)
        {
            _dbContext.Sessions.Update(session);
            return _dbContext.SaveChanges();
        }
    }
}
