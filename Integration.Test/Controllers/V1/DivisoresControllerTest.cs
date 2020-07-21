using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Application.Models.Responses.Disvisores;

namespace Integration.Test.Controllers
{
    public class DivisoresControllerTest : IClassFixture<ProgramTest>
    {
        private readonly IHost _host;
        private const string _get_divisores = "/v1/divisores";

        public DivisoresControllerTest(ProgramTest program)
        {
            _host = program.Host;
        }

        [Theory]
        [InlineData(40)]
        public async Task Get_divisores(int num)
        {
            var request = _host.GetTestServer().CreateRequest(_get_divisores + $"?num={num}");


            var result = await request.GetAsync().ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            var content = await result.Content.ReadAsStringAsync().ConfigureAwait(false);

            var filtro = JsonConvert.DeserializeObject<DivisoresResponse>(content);

            Assert.True(filtro?.Divisores?.Any());
        }
    }
}
