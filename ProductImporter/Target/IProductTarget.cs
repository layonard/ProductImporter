using ProductImporterApp.Model;

namespace ProductImporterApp.Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
