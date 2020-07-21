using Common.Extensions;
using Application.BLLs.Base;
using Application.Interfaces.BLLs;
using Application.Models.Responses.Disvisores;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.BLLs
{
    public class DivisorBll : BaseBll<DivisorBll>, IDivisorBll
    {
        public DivisorBll(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public DivisorBll() : base()
        {
        }


        public async Task<DivisoresResponse> GerarDivisores(int num)
        {
            return await Task.Run(() =>
              {
                  try
                  {
                      var listaDivisores = new List<int>();
                      CalculaDivisores(num, num, listaDivisores);

                      return new DivisoresResponse()
                      {
                          Divisores = listaDivisores,
                          DivisoresPrimos = listaDivisores.Where(x => x.EPrimo()).ToList()
                      };
                  }
                  catch(Exception e)
                  {
                      base.Logger.LogError(e, e.Message, nameof(GerarDivisores));
                      throw;
                  }
              });
        }


        private void CalculaDivisores(int num, int divisor, List<int> divisores)
        {
            if (divisor == 0)
                return;

            if (num % divisor == 0)
                divisores.Add(divisor);

            CalculaDivisores(num, divisor - 1, divisores);
        }
    }
}
