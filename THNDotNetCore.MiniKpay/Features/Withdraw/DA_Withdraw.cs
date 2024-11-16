﻿using THNDotNetCore.MiniKpay.Features.User;
using THNDotNetCore.MiniKpay.Services;

namespace THNDotNetCore.MiniKpay.Features.Withdraw
{
    public class DA_Withdraw
    {
        private readonly UserService _userService;

        public DA_Withdraw(UserService userService)
        {
            _userService = userService;
        }

        public UserResponseModel GetUserByMobileNo(string mobileNo)
        {
            UserResponseModel response = new UserResponseModel();
            var user = _userService.GetUserByMobileNo(mobileNo);
            if (user is null)
            {
                response.RespCode = "I0001";
                response.RespDescription = "User not found";
                return response;
            }
            response.user = user;
            response.RespCode = "I0000";
            response.RespDescription = "Success";
            return response;
        }

        public UserResponseModel UpdateUser(int id, UserModel user)
        {
            UserResponseModel response = new UserResponseModel();
            var result = _userService.UpdateUser(id, user);
            if (result == 0)
            {
                response.RespCode = "I0004";
                response.RespDescription = "Update fail";
                return response;
            }
            response.RespCode = "I0000";
            response.RespDescription = "Success";
            response.user = user;
            return response;
        }
    }
}