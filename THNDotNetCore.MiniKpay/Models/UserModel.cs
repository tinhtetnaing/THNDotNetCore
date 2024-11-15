using System.ComponentModel.DataAnnotations.Schema;

namespace THNDotNetCore.MiniKpay.Models
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
}
