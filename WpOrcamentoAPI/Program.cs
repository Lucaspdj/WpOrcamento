using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using WpOrcamentoAPI.Helper;

namespace WpOrcamentoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {

            BuildWebHostAsync(args).GetAwaiter().GetResult().Run();
        }

        public static async Task<IWebHost> BuildWebHostAsync(string[] args)
        {
            var url = await AuxNotStatic.GetInfoMotorAux("WpOrcamento", 1);
            return WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>()
                 .UseUrls(url.Url)
                 .Build();
        }
    }
}
