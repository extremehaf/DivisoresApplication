
using System.Threading.Tasks;
using Application.Models.Responses.Disvisores;

namespace Application.Interfaces.BLLs
{
    public interface IDivisorBll
    {
        Task<DivisoresResponse> GerarDivisores(int num);       
    }
}
