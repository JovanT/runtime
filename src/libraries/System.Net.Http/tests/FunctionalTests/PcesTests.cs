// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace System.Net.Http.Functional.Tests
{

    public class PcesTests : HttpClientHandlerTestBase
    {
        public PcesTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public async void Send_HttpPost_Debug()
        {
            var client = new HttpClient() {
                Timeout = TimeSpan.FromMinutes(10),
            };

            var payload = new {
                Test = "test"
            };

            var response = await client.PostAsync("https://localhost:44356/", new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

            client.Dispose();
        }
    }
}
