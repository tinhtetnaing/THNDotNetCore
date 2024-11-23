using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace THNDotNetCore.MiniKpay.Api.Features.Deposit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly BL_Deposit _deposit;

        public DepositController(BL_Deposit deposit)
        {
            _deposit = deposit;
        }

        [HttpPost]
        public IActionResult Deposit(string phoneNumber, decimal amount, int pin)
        {
            var response = _deposit.Deposit(phoneNumber, amount, pin);
            if (response.RespCode != "I0000")
            {
                return BadRequest(response.RespDescription);
            }
            return Ok(response);
        }
    }
}
