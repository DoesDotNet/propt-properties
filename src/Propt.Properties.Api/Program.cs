using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Propt.Properties.Application.Commands;
using Propt.Properties.Application.Data;
using Propt.Properties.Application.Mappings;
using Propt.Properties.Cosmos.Repository;
using Propt.Properties.Cosmos.Repository.Mappings;
using System.Threading.Tasks;

namespace Propt.Properties.Api
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<CosmosSettings>(hostContext.Configuration.GetSection("CosmosSettings"));

                    services.AddMediatR(typeof(CreateProperty).Assembly);
                    services.AddScoped<IRepository, CosmosRepository>();

                    services.AddAutoMapper(config =>
                    {
                        CosmosMappingConfigurator.Configure(config);
                        DomainMappingConfigurator.Configure(config);
                    });
                })
                .Build();

            await host.RunAsync();
        }
    }
}