using System.ComponentModel.DataAnnotations.Schema;

namespace THNDotNetCore.MiniKpay.Features.Transfer
{
    [Table("Transfer")]
    public class TransferModel
    {
        public int Id {  get; set; }
        public string FromMobileNo { get; set; }
        public string ToMobileNo { get; set; }
        public decimal Amount { get; set; }
        public int Pin { get; set; }
        public string? Note { get; set; }
    }

    public class TransferResponseModel
    {
        public string RespCode { get; set; }
        public string RespDescription { get; set; }
        public TransferModel Transfer {  get; set; }
        public List<TransferModel> TransferLst { get; set; }
    }
}
