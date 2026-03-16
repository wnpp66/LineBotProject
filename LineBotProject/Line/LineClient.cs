using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;

namespace LineBotProject.Line
{


    public class LineClient
    {
        private readonly HttpClient _http;
        private readonly string token = "CHANNEL_ACCESS_TOKEN";

        public LineClient()
        {
            _http = new HttpClient();
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task ReplyText(string replyToken, string text)
        {
            var payload = new
            {
                replyToken = replyToken,
                messages = new[]
                {
                new {
                    type = "text",
                    text = text
                }
            }
            };

            var json = JsonConvert.SerializeObject(payload);

            await _http.PostAsync(
                "https://api.line.me/v2/bot/message/reply",
                new StringContent(json, Encoding.UTF8, "application/json")
            );
        }
    }
}
