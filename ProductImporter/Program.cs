using ProductImporterApp;
using ProductImporterApp.Shared;
using ProductImporterApp.Source;
using ProductImporterApp.Target;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<Configuration>();

        services.AddTransient<IPriceParser, PriceParser>();
        services.AddTransient<IProductSource, ProductSource>();

        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, ProductTarget>();

        services.AddTransient<ProductImporter>();
    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();

productImporter.Run();