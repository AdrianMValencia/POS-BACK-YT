using POS.Infrastructure.Commons.Bases.Response;

namespace POS.Application.Interfaces
{
    public interface IGenerateExcelApplication
    {
        byte[] GenerateToExcel<T>(BaseEntityResponse<T> data, List<(string ColumnName, string PropertyName)> columns);
    }
}