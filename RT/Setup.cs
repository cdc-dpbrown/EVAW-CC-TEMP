using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace RT
{
    public class Setup
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public void CallCheck()
        {
            Assert.Equal(null, null);
        }

        [Theory]
        [InlineData(@"http://localhost:51110/")]
        public async void WebApiRunning(string URL)
        {
            var values = new Dictionary<string, string>{};
            var content = new FormUrlEncodedContent(values);

            System.Net.Http.HttpResponseMessage response = null;

            try
            {
                response = await client.PostAsync(URL + "api/login", content);
            }
            catch (Exception exception)
            {
                Console.Write("CheckWinApi-Exception::" + exception.Message);
            }

            Assert.NotEqual(response, null);
        }
    }
}
