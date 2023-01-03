using ProductImporterApp.Model;

namespace ProductImporterApp.Source;

public interface IPriceParser
{
    Money Parse(string price);
}
