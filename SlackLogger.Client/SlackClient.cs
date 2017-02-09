using System.Net.Http;
using System.Threading.Tasks;

namespace SlackLogger.Client {
	public class SlackClient {
		private readonly string _webhookUrl;

		public SlackClient(string webhookUrl) {
			_webhookUrl = webhookUrl;
		}

		public async Task Send(string payload) {
			using (HttpClient client = new HttpClient()) {				
				StringContent content = new StringContent(payload);
				await client.PostAsync(_webhookUrl, content);
			}
		}
	}
}