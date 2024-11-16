using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace THNDotNetCore.MiniKpay.Features.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly BL_Transfer _transfer;

        public TransferController(BL_Transfer transfer)
        {
            _transfer = transfer;
        }

        [HttpPost]
        public IActionResult Transfer(TransferModel transfer)
        {
            var response = _transfer.Transfer(transfer);
            if(response.RespCode != "I0000")
            {
                return BadRequest(response.RespDescription);
            }
            return Ok(response);
        }
    }
}
