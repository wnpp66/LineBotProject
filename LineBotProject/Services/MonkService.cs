using LineBotProject.Line;
namespace LineBotProject.Services
{
    

    public class MonkService
    {
        private readonly LineClient _line;

        public MonkService(LineClient line)
        {
            _line = line;
        }

        public async Task Search(string replyToken, string message)
        {
            var keyword = message.Replace("ค้นหาพระ", "").Trim();

            // ตัวอย่างข้อมูล
            var monks = new List<string>
        {
            "พระสมชาย สุขิโต",
            "พระสมศักดิ์ ธัมมิโก"
        };

            var result = string.Join("\n", monks);

            await _line.ReplyText(replyToken, result);
        }
    }
}
