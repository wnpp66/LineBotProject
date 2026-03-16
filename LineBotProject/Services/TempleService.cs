using LineBotProject.Line;
namespace LineBotProject.Services
{
    

    public class TempleService
    {
        private readonly LineClient _line;

        public TempleService(LineClient line)
        {
            _line = line;
        }

        public async Task Search(string replyToken, string message)
        {
            var temples = new List<string>
        {
            "วัดหนองป่าพง",
            "วัดป่านานาชาติ"
        };

            var text = string.Join("\n", temples);

            await _line.ReplyText(replyToken, text);
        }
    }
}
