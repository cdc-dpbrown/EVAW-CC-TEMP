using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace RT
{
    public class Credentials
    {
        private static readonly HttpClient client = new HttpClient();

        [Fact]
        public void CallCheck()
        {
            Assert.Equal(null, null);
        }

        [Theory]
        [InlineData(@"http://localhost:51110/", "sax5@cdc.gov", "", "00261489-ab79-4587-aa52-0d1a7b35f643")]
        [InlineData(@"http://localhost:51110/", "ita3@cdc.gov", "", "00261489-ab79-4587-aa52-0d1a7b35f643")]
        [InlineData(@"http://localhost:51110/", "sax5@cdc.gov", "", "")]
        public async void LoginAsync(string URL, string id, string password, string canvasId)
        {
            var values = new Dictionary<string, string>
            {
               { "id", id },
               { "password", password },
               { "canvasid", canvasId}
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(URL + "api/login", content);
            var responseString = await response.Content.ReadAsStringAsync();
            
            Console.Write("LoginAsync::" + responseString);

            Assert.Contains("UserID", responseString);
            Assert.Contains("UserName", responseString);
            Assert.Contains("UserRoleInOrganization", responseString);
        }
    }
}
