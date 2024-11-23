using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace THNDotNetCore.MiniKpay.Api.Features.Withdraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {

        private readonly BL_Withdraw _withdraw;

        public WithdrawController(BL_Withdraw withdraw)
        {
            _withdraw = withdraw;
        }

        [HttpPost]
        public IActionResult Withdraw(string mobileNo, decimal amount, int pin)
        {
            var response = _withdraw.Withdraw(mobileNo, amount, pin);
            if (response.RespCode != "I0000")
            {
                return BadRequest(response.RespDescription);
            }
            return Ok(response);
        }
    }
}
