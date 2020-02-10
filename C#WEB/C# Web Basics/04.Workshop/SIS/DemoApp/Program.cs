namespace DemoApp
{
    using SIS.MvcFramework;
    using System.Threading.Tasks;

    class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}
