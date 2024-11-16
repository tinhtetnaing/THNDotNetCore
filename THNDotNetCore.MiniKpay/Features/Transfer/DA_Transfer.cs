using THNDotNetCore.MiniKpay.Features.Deposit;
using THNDotNetCore.MiniKpay.Features.User;
using THNDotNetCore.MiniKpay.Services;

namespace THNDotNetCore.MiniKpay.Features.Transfer
{
    public class DA_Transfer
    {
        private readonly UserService _userService;
        private readonly TransferService _transferService;

        public DA_Transfer(UserService userService, TransferService transferService)
        {
            _userService = userService;
            _transferService = transferService; 
        }

        public TransferResponseModel GetTransfers()
        {
            TransferResponseModel response = new TransferResponseModel();
            var lst = _transferService.GetTransfers();
            if(lst is null)
            {
                response.RespCode = "I0001";
                response.RespDescription = "No Transaction History";
                return response;
            }
            response.TransferLst = lst;
            response.RespCode = "I0000";
            response.RespDescription = "Success";
            return response;
        }

        public TransferResponseModel CreateTransfer(TransferModel model)
        {
            TransferResponseModel response = new TransferResponseModel();
            var result = _transferService.CreateTransfer(model);
            if(result == 0)
            {
                response.RespCode = "I0001";
                response.RespDescription = "Create Fail";
                return response;
            }
            response.RespCode = "I0000";
            response.RespDescription = "Success";
            return response;
        }
    }
}
