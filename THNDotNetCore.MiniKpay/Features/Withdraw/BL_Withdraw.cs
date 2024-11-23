using THNDotNetCore.MiniKpay.Database.Models;

namespace THNDotNetCore.MiniKpay.Api.Features.Withdraw
{
    public class BL_Withdraw
    {
        private readonly DA_Withdraw _daWithdraw;

        public BL_Withdraw(DA_Withdraw daWithdraw)
        {
            _daWithdraw = daWithdraw;
        }

        public UserResponseModel Withdraw(string mobileNo, decimal amount, int pin)
        {
            var response = _daWithdraw.GetUserByMobileNo(mobileNo);
            if (response.RespCode != "I0000")
            {
                return response;
            }
            if (amount <= 0)
            {
                response.RespCode = "I0002";
                response.RespDescription = "Amount must be greater than 0";
                return response;
            }
            if (response.user.Pin != pin)
            {
                response.RespCode = "I0003";
                response.RespDescription = "Wrong PIN";
                return response;
            }
            if (response.user.Balance < amount)
            {
                response.RespCode = "I0004";
                response.RespDescription = "No enough Balance";
                return response;
            }
            response.user.Balance -= amount;
            var result = _daWithdraw.UpdateUser(response.user.Id, response.user);
            return result;
        }
    }
}
