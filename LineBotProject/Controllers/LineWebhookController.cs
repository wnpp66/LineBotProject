using Microsoft.AspNetCore.Mvc;
using System.Text;
using LineBotProject.Chatbot;

namespace LineBotProject.Controllers
{

    [ApiController]
    [Route("webhook")]
    public class LineWebhookController : ControllerBase
    {
        private readonly CommandRouter _router;

        public LineWebhookController(CommandRouter router)
        {
            _router = router;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            var body = await reader.ReadToEndAsync();

            await _router.Handle(body);

            return Ok();
        }
    }
}
