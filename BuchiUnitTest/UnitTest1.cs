using Buchitestplanfun;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace BuchiUnitTest
{
    public class UnitTest1 : Controller
    {

        [Theory]
        [InlineData("a")]
        public async Task Test1(string a)
        {
            var queryStringValue = a;
            var request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = new QueryCollection
                (
                    new Dictionary<string, StringValues>()
                    {
                        { "message", queryStringValue }
                    }
                )
            };

            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            var response = await Function1.Run(request, logger);
            var result = response;

            Assert.Equal("OK", result);
        }

    }
}
