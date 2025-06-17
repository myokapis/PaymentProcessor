using Microsoft.AspNetCore.Mvc;
using TsysProcessor.Processor;
using TsysProcessor.Transaction.Model;

namespace PaymentProcessorUI.Controllers
{
    public class CardPaymentController : Controller
    {
        private readonly TsysTransactionRunner workflowRunner;

        public CardPaymentController(TsysTransactionRunner workflowRunner)
        {
            this.workflowRunner = workflowRunner;
        }

        [HttpGet("CardPayment/Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("/cardpayment/payment/")]
        public async Task<IActionResult> Payment([FromBody] TsysTransaction transaction)
        {
            if (!ModelState.IsValid)
            {
                var x = ModelState.Values.SelectMany(m => m.Errors.Select(e => e.ErrorMessage));
                // TODO: log failure messages

                return BadRequest("Transaction was improperly formatted.");
            }

            await workflowRunner.RunAsync(transaction);
            var request = workflowRunner.WorkflowContext.SerializedRequest;

            return Ok(request);
        }
    }
}
