using System.Text;

namespace ProductImporterApp.Shared;

public class ImportStatistics : IImportStatistics
{
    private int _productsImportedCount;
    private int _productsOutputtedCount;

    public void IncrementImportCount()
    {
        _productsImportedCount++;
    }

    public void IncrementOutputCount()
    {
        _productsOutputtedCount++;
    }
    public string GetStatistics()
    {
        var sb = new StringBuilder();
        sb.Append($"Read a total of {_productsImportedCount} products from source");
        sb.AppendLine();
        sb.Append($"Written a total of {_productsOutputtedCount} products on target");

        return sb.ToString();
    }
}