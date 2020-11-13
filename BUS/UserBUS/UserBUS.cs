using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BUS.UserBUS
{
    public class UserBUS
    {
        private IUser _user = new DAL.Functions.UserFunctions();
        //Add a new User
        public async Task<Boolean> CreateNewUser(string username, string password,string email, int authLevelId)
        {
            await _user.Adduser(username, password, email, authLevelId);
            return true;
        }

       
        //get all
        public async Task<List<User>> GetAllUser()
        {
            List<User> users = await _user.GetAllUsers();
            return users;
        }
        //Get User
        public async Task<User> GetUser(long Id)
        {
            var user = await _user.GetUser(Id);
            return user;
        }
        //Delete
        public async Task<Boolean> DeleteUser(long Id)
        {
            await _user.DeleteUser(Id);
            return true;
        }
    }
}
