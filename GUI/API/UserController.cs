using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUS.UserBUS;
using GUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GUI.API
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserBUS userBUS = new UserBUS();
        [Route("all")]
        [HttpGet]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> userList = new List<UserViewModel>();
            var users = await userBUS.GetAllUser();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    UserViewModel currentUser = new UserViewModel
                    {
                        Id = user.Id,
                        Username = user.Username,
                        Password = user.Password,
                        Email = user.Email,
                        AuthLevelId = user.AuthLevelRefId
                    };
                    userList.Add(currentUser);
                }
            }
            return userList;
        }

        //Create
        [Route("create")]
        [HttpPost]
        
        public async Task<Boolean> CreateUser(UserViewModel userVM)
        {
            await userBUS.CreateNewUser(userVM.Username, userVM.Password, userVM.Email, userVM.AuthLevelId);
            return true;
        }
        
        [Route("all/{id}")]
        [HttpGet]
        public async Task<UserViewModel> GetUser(long Id)
        {
            var user = await userBUS.GetUser(Id);
            UserViewModel userVM = new UserViewModel{
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                AuthLevelId = user.AuthLevelRefId
            };
            return userVM;
        }
        [Route("all/{id}")]
        [HttpDelete]
        public async Task<Boolean> DeleteUser(long Id)
        {
            bool result = await userBUS.DeleteUser(Id);
            return result;
        }
    }
}
