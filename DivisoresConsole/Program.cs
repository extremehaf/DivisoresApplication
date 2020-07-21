using System;
using System.Linq;
using Application.BLLs;
namespace DivisoresConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o numero de entrada: ");
            int num = 0;
            try
            {
                num = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Número inválido");
                return;
            }
            
            var divisoresBll = new DivisorBll();


            var result = divisoresBll.GerarDivisores(num).Result;



            Console.Write($"{nameof(result.Divisores)}: ");
            result.Divisores.ForEach(item =>
            {
                if(item.Equals(result.Divisores.Last()))
                    Console.Write($"{item}");
                else
                    Console.Write($"{item}, ");
            });
            Console.WriteLine("");
            Console.Write($"{nameof(result.DivisoresPrimos)}: ");
            result.DivisoresPrimos.ForEach(item =>
            {
                if (item.Equals(result.DivisoresPrimos.Last()))
                    Console.Write($"{item}");
                else
                    Console.Write($"{item}, ");
            });

            Console.ReadKey();
        }
    }
}
