using System;
using System.Net.Http;

namespace webapi.test.integration
{
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