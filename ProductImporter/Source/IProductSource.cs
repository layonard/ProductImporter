using ProductImporterApp.Model;

namespace ProductImporterApp.Source;

public interface IProductSource
{
    void Open();
    bool hasMoreProducts();
    Product GetNextProduct();
    void Close();
}