using ProductImporterApp;
using ProductImporterApp.Shared;
using ProductImporterApp.Source;
using ProductImporterApp.Target;

var configuration = new Configuration();
var priceParser = new PriceParser();

var productSource = new ProductSource(configuration, priceParser);

var productFomatter = new ProductFormatter();

var productTarget = new ProductTarget(configuration, productFomatter);

var ProductImporterApp = new ProductImporter(productSource, productTarget);
ProductImporterApp.Run();