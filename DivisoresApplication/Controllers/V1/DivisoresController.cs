using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models.Responses.Disvisores;
using Application.Interfaces.BLLs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DivisoresApplication.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class DivisoresController : ControllerBase
    {
        

        private readonly ILogger<DivisoresController> _logger;
        private readonly IDivisorBll _divisorBll;
        public DivisoresController(ILogger<DivisoresController> logger, IDivisorBll divisorBll)
        {
            _logger = logger;

            _divisorBll = divisorBll;
        }

        [HttpGet]
        public async Task<DivisoresResponse> Get(int num)
        {
            if (num <= 0)
                BadRequest($"{nameof(num)} inválido");

            return await _divisorBll.GerarDivisores(num).ConfigureAwait(false);
        }
    }
}
