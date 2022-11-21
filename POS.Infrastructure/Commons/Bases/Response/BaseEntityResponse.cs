namespace POS.Infrastructure.Commons.Bases.Response
{
    public class BaseEntityResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}