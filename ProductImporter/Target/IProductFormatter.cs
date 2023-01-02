using ProductImporterApp.Model;

namespace ProductImporterApp.Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
