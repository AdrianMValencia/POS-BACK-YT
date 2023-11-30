using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Dtos.Product.Response
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public string? Image { get; set; }
        public decimal UnitSalePrice { get; set; }
        public string? Category { get; set; }
        public DateTime? AuditCreateDate {  get; set; }
        public int State {  get; set; }
        public string? StateProduct { get; set; }
    }
}