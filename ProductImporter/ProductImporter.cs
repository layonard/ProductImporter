using ProductImporterApp.Shared;
using ProductImporterApp.Source;
using ProductImporterApp.Target;

namespace ProductImporterApp;
public class ProductImporter
{
    private readonly IProductSource _productSource;
    private readonly IProductTarget _productTarget;
    private readonly IImportStatistics _importStatistics;

    public ProductImporter(IProductSource productSource, IProductTarget productTarget, IImportStatistics importStatistics)
    {
        _productSource = productSource;
        _productTarget = productTarget;
        _importStatistics = importStatistics;
    }

    public void Run()
    {
        _productSource.Open();
        _productTarget.Open();

        while (_productSource.hasMoreProducts())
        {
            var product = _productSource.GetNextProduct();
            _productTarget.AddProduct(product);
        }

        _productSource.Close();
        _productTarget.Close();

        Console.WriteLine("Import complete!");
        Console.WriteLine(_importStatistics.GetStatistics());
    }
}