using System;
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
    public class StepDefinition1
    {
        private readonly MyContext _context;
        private readonly HttpClient _client;

        public StepDefinition1(MyContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _client = clientFactory.CreateClient(nameof(StepDefinition1));
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

    public class MyContext
    {
        public HttpResponseMessage Response { get; set; }
    }

    public static class Extensions
    {
        public static HttpMethod ToHttpMethod(this string httpMethod)
        {
            return httpMethod.ToUpper() switch
            {
                "GET" => HttpMethod.Get,
                "POST" => HttpMethod.Post,

                _ => throw new ArgumentOutOfRangeException(nameof(httpMethod), httpMethod, "")
            };
        }
    }


}
