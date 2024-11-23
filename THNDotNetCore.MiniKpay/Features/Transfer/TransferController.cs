using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THNDotNetCore.MiniKpay.Database.Models;

namespace THNDotNetCore.MiniKpay.Api.Features.Transfer
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

        [HttpGet]
        [Route("TransactionHistory")]
        public IActionResult TransactionHistory()
        {
            var response = _transfer.GetTranfers();
            if (response.RespCode != "I0000")
            {
                return BadRequest(response.RespCode);
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Transfer(TransferModel transfer)
        {
            var response = _transfer.Transfer(transfer);
            if (response.RespCode != "I0000")
            {
                return BadRequest(response.RespDescription);
            }
            return Ok(response);
        }
    }
}
