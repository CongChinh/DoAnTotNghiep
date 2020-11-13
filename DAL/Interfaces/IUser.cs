using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser
    {

        Task<User> Adduser(string username, string password, string email, int authLeveLId);

        Task<List<User>> GetAllUsers();

        Task<User> GetUser(long Id);

        Task<User> UpdateUser(long Id);

        Task<User> DeleteUser(long Id);

    }
}
