using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SlackLogger.Client {
	public class SlackClient {
		private readonly string _webhookUrl;

		public SlackClient(string webhookUrl) {
			_webhookUrl = webhookUrl;
		}        

        public async Task Send(string payload) {
			using (HttpClient client = new HttpClient()) {
                payload = EscapePayload(payload);
                System.Console.WriteLine(payload);
                StringContent content = new StringContent(payload);
				await client.PostAsync(_webhookUrl, content);
			}
		}

        private string EscapePayload(string value) {
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}