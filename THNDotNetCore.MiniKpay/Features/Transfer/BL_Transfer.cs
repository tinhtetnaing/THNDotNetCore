using System.Net.NetworkInformation;
using THNDotNetCore.MiniKpay.Features.Deposit;
using THNDotNetCore.MiniKpay.Features.User;

namespace THNDotNetCore.MiniKpay.Features.Transfer
{
    public class BL_Transfer
    {
        private readonly DA_Transfer _transfer;
        private readonly DA_Deposit _deposit;

        public BL_Transfer(DA_Transfer transfer, DA_Deposit deposit)
        {
            _transfer = transfer;
            _deposit = deposit;
        }

        public TransferResponseModel GetTranfers()
        {
            var response = _transfer.GetTransfers();
            return response;
        }

        public TransferResponseModel Transfer(TransferModel transfer)
        {
            TransferResponseModel response = new TransferResponseModel();
            if(transfer.FromMobileNo == transfer.ToMobileNo)
            {
                response.RespCode = "I0005";
                response.RespDescription = "Mobile Numbers must not be the same";
                return response;
            }
            var fromUser = _deposit.GetUserByMobileNo(transfer.FromMobileNo);
            if(fromUser is null)
            {
                response.RespCode = "I0001";
                response.RespDescription = "User not found";
                return response;
            }
            if(fromUser.user.Balance < transfer.Amount)
            {
                response.RespCode = "I0003";
                response.RespDescription = "No enough balance";
                return response;
            }
            if (fromUser.user.Pin != transfer.Pin)
            {
                response.RespCode = "I0003";
                response.RespDescription = "Wrong PIN";
                return response;
            }
            var toUser = _deposit.GetUserByMobileNo(transfer.ToMobileNo);
            if (toUser is null)
            {
                response.RespCode = "I0001";
                response.RespDescription = "User not found";
                return response;
            }
            fromUser.user.Balance -= transfer.Amount;
            var fromUserResponse = _deposit.UpdateUser(fromUser.user.Id, fromUser.user);
            toUser.user.Balance += transfer.Amount;
            var toUserResponse = _deposit.UpdateUser(toUser.user.Id, toUser.user);
            if (fromUserResponse is null || toUserResponse is null)
            {
                response.RespCode = "I0006";
                response.RespDescription = "Transfer fail";
                return response;
            }
            // Transfer Log
            var transferResp = _transfer.CreateTransfer(transfer);
            if (transferResp is null)
            {
                response.RespCode = "I0001";
                response.RespDescription = "Fail";
                return response;
            }
            response.RespCode = "I0000";
            response.RespDescription = "Success";
            response.Transfer = transfer;
            return response;
        }
    }
}
