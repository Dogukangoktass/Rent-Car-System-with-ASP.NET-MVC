using RCP.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCP.BL
{
   public class UserRepository:BaseRepository<User>
    {
        public User Login(string email, string password,string username)
        {
          return context.Set<User>().Where(x => x.Email == email || x.Username == username && x.Password == password).FirstOrDefault();
        }

        public bool AddRole(int userId, int roleId)
        {
            SqlParameter[] parameters = { new SqlParameter("userId", userId), new SqlParameter("rolId", roleId) };
            int result = context.Database.ExecuteSqlCommand("insert into UserRole (UserId, RoleId) values (@userId,@rolId)", parameters);
            return result > 0 ? true : false;
        }
    }
}
