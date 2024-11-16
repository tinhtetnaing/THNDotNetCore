using System.ComponentModel.DataAnnotations.Schema;

namespace THNDotNetCore.MiniKpay.Features.User
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public decimal Balance { get; set; }
        public int Pin { get; set; }
    }

    public class UserResponseModel
    {
        public string RespCode { get; set; }
        public string RespDescription { get; set; }
        public UserModel user { get; set; }
    }

}
