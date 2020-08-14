using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace webapi.test.integration.Steps
{
    [Binding]
    public class ApiSteps
    {
        private readonly ApiContext _context;
        private readonly HttpClient _client;

        public ApiSteps(ApiContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _client = clientFactory.CreateClient(nameof(ApiSteps));
        }


        [When(@"I send a '(.*)' request to '(.*)'")]
        public async Task WhenISendARequestTo(string httpMethod, string endpoint)
        {
            _context.Response = await _client.SendAsync(new HttpRequestMessage(httpMethod.ToHttpMethod(), endpoint));
        }

        [Then(@"StatusCode should be '(.*)'")]
        public void ThenStatusCodeShouldBe(HttpStatusCode statusCode)
        {
            _context.Response.StatusCode.Should().Be(statusCode);
        }

        [Then(@"content equals to '(.*)'")]
        public async Task ThenContentEqualsTo(string expectedContent)
        {
            var responseBody = await _context.Response.Content.ReadAsStringAsync();
            responseBody.Should().Be(expectedContent);
        }

    }
}
