using THNDotNetCore.MiniKpay.Database.Models;
namespace THNDotNetCore.MiniKpay.Api.Features.Deposit
{
    public class BL_Deposit
    {
        private readonly DA_Deposit _daDeposit;

        public BL_Deposit(DA_Deposit daDeposit)
        {
            _daDeposit = daDeposit;
        }

        public UserResponseModel Deposit(string mobileNo, decimal amount, int pin)
        {
            var response = _daDeposit.GetUserByMobileNo(mobileNo);
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
            response.user.Balance += amount;
            var result = _daDeposit.UpdateUser(response.user.Id, response.user);
            return result;
        }
    }
}
