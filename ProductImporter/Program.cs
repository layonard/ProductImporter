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

        services.AddSingleton<IImportStatistics, ImportStatistics>();

        services.AddScoped<ScopedSample>(); //Test scoped lifecicle
    })
    .Build();

/*
var productImporter = host.Services.GetRequiredService<ProductImporter>();

productImporter.Run();
*/

CompareInstancesLifecicle();

void CompareInstancesLifecicle()
{
    Console.WriteLine("---- COMPARE LIFECICLES ----");
    Console.WriteLine("TRANSIENT");
    var productImporter1 = host.Services.GetService<ProductImporter>();
    var productImporter2 = host.Services.GetService<ProductImporter>();
    Console.WriteLine("Is productImporter1 equals to productImporter2?");
    Console.WriteLine(Object.ReferenceEquals(productImporter1, productImporter2));

    Console.WriteLine("SINGLETON");
    var importStatistics1 = host.Services.GetService<IImportStatistics>();
    var importStatistics2 = host.Services.GetService<IImportStatistics>();
    Console.WriteLine("Is importStatistics1 equals to importStatistics2?");
    Console.WriteLine(Object.ReferenceEquals(importStatistics1, importStatistics2));

    Console.WriteLine("SCOPED");
    using var firstScope = host.Services.CreateScope();
    var resolvedOnce = firstScope.ServiceProvider.GetRequiredService<ScopedSample>();
    var resolvedTwice = firstScope.ServiceProvider.GetRequiredService<ScopedSample>();
    var isSameinFirstScope = Object.ReferenceEquals(resolvedOnce, resolvedTwice);
    
    using var secondScope = host.Services.CreateScope();
    var resolvedThrice = secondScope.ServiceProvider.GetRequiredService<ScopedSample>();
    var resolvedForth = secondScope.ServiceProvider.GetRequiredService<ScopedSample>();
    var isSameinSecondScope = Object.ReferenceEquals(resolvedThrice, resolvedForth);
    var isSameCrossScope = Object.ReferenceEquals(resolvedOnce, resolvedForth);

    Console.WriteLine($"{nameof(isSameinFirstScope)}? {isSameinFirstScope}");
    Console.WriteLine($"{nameof(isSameinSecondScope)}? {isSameinSecondScope}");
    Console.WriteLine($"{nameof(isSameCrossScope)}? {isSameCrossScope}");
}