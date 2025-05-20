using Microsoft.AspNetCore.Mvc;
using PaymentProcessor.Processor;
using PaymentProcessor.Transaction;

namespace PaymentProcessorUI.Controllers
{
    public class CardPaymentController : Controller
    {
        private readonly IProcessRunner processRunner;

        public CardPaymentController(IProcessRunner processRunner)
        {
            this.processRunner = processRunner;
        }

        //[HttpGet("CardPayment/Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("/cardpayment/payment/")]
        public async Task<IActionResult> Payment([FromBody] Body transaction)
        {
            if (!ModelState.IsValid)
            {
                var x = ModelState.Values.SelectMany(m => m.Errors.Select(e => e.ErrorMessage));
                // TODO: log failure messages

                return BadRequest("Transaction was improperly formatted.");
            }

            await processRunner.RunAsync(transaction);
            var request = processRunner.ProcessContext.SerializedRequest;

            return Ok(request);
        }
    }
}
