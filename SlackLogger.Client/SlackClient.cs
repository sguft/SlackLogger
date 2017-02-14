using System;
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
            try {
                using (HttpClient client = new HttpClient()) {
                    payload = EscapePayload(payload);
                    System.Console.WriteLine(payload);
                    StringContent content = new StringContent(payload);
                    HttpResponseMessage response = await client.PostAsync(_webhookUrl, content);
                    Console.WriteLine("Status Code: " + response.StatusCode);
                    Console.WriteLine("Response: " + await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                throw ex;
            }
		}

        private string EscapePayload(string value) {
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }
}