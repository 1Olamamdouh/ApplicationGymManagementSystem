using GymManagementDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    internal interface ISessionRepository
    {

        //GetAllSession
        IEnumerable<Session> GetAllSessions();
        //GetSessionById
        Session? GetSession(int id);
        //AddSession
        int AddSession(Session session);
        //UpdateSession
        int UpdateSession(Session session);
        //DeleteSession
        int DeleteSession(Session session);



    }
}
