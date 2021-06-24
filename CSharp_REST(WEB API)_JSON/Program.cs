using Refit;
using System;
using System.Threading.Tasks;

namespace CSharp_REST_WEB_API__JSON
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var CodCotacao = RestService.For<ApiService>("https://restapi.anticheats.com.br");
                Console.WriteLine("Informe o Código da Cotação:");
                string CodInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informação com referêcia em: " + CodInformado);
                var address = await CodCotacao.GetAddressAsync(CodInformado);
                Console.WriteLine($"\nCódigo:{address.cod_cotacao}\nValor da cotação:{address.vlr_cotacao}\nData da cotação:{address.dat_cotacao}");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro ao obter dados: " + e.Message);
            }
        }
    }
}
