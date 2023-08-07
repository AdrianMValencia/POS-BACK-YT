using POS.Infrastructure.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Infrastructure.FileExcel
{
    public interface IGenerateExcel
    {
        MemoryStream GenerateToExcel<T>(BaseEntityResponse<T> data, List<TableColumn> columns);
    }
}