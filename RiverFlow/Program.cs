using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiverFlow.Services;

namespace RiverFlow;

class Program
{
    private const string DataFilePath = "MeasuredData.csv"; 
    
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        var riverFlowService = host.Services.GetService<IRiverFlowService>();
        
        var result = riverFlowService?.CalculateRiverFlow(DataFilePath);
        
        Console.WriteLine($"Calculated river flow is {result:F2} m^3");
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IDataImportService, DataImportService>();
                services.AddSingleton<IRiverFlowService, RiverFlowService>();
            });
}