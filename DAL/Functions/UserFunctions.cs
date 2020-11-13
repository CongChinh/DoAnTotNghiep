using DAL.DataConnext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class UserFunctions:IUser
    {
        //Add new user
        public async Task<User> Adduser(string username, string password, string email, int authLevelId)
        {
            User newUser = new User
            {
                Username = username,
                Password = password,
                Email = email,
                AuthLevelRefId = authLevelId
            };
            using(var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();
            }
            return newUser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();
            
            using (var context =  new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }


        //Get user
        public async Task<User> GetUser(long Id)
        {
            User user = new User();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                user = await context.Users.FindAsync(Id);
            }
            return user;
        }

        public async Task<User> UpdateUser(long Id)
        {
            User user = new User();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                user = await context.Users.FindAsync(Id);
            }
            return null;
        }
        public async Task<User> DeleteUser(long Id)
        {
            User user = new User();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                user = await context.Users.FindAsync(Id);
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            return null;
        }
    }
}
