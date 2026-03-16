using Newtonsoft.Json.Linq;
using LineBotProject.Services;

namespace LineBotProject.Chatbot
{

    public class CommandRouter
    {
        private readonly MonkService _monkService;
        private readonly TempleService _templeService;

        public CommandRouter(MonkService monkService, TempleService templeService)
        {
            _monkService = monkService;
            _templeService = templeService;
        }

        public async Task Handle(string body)
        {
            var json = JObject.Parse(body);

            var message = json["events"]?[0]?["message"]?["text"]?.ToString();
            var replyToken = json["events"]?[0]?["replyToken"]?.ToString();

            if (message == null) return;

            if (message.Contains("ค้นหาพระ"))
            {
                await _monkService.Search(replyToken, message);
            }
            else if (message.Contains("ค้นหาวัด"))
            {
                await _templeService.Search(replyToken, message);
            }
        }
    }
}
