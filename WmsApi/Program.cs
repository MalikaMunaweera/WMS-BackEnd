using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WmsApi
{
    public class Program
    {
        //Scaffold-DbContext "Data Source=192.168.8.101;Initial Catalog=WMS;Persist Security Info=True;User ID=sa;Password=38340677" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Force
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
