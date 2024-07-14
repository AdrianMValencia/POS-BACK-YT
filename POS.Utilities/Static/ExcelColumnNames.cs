namespace POS.Utilities.Static
{
    public class ExcelColumnNames
    {
        public static List<TableColumn> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperties)
        {
            var columns = new List<TableColumn>();

            foreach (var (ColumnName, PropertyName) in columnsProperties)
            {
                var column = new TableColumn()
                {
                    Label = ColumnName,
                    PropertyName = PropertyName
                };

                columns.Add(column);
            }

            return columns;
        }

        #region ColumnsCategories
        public static List<(string ColumnName, string PropertyName)> GetColumnsCategories()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("DESCRIPCIÓN", "Description"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateCategory")
            };

            return columnsProperties;
        }
        #endregion

        #region ColumnsProviders
        public static List<(string ColumnName, string PropertyName)> GetColumnsProviders()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("EMAIL", "Email"),
                ("TIPO DE DOCUMENTO", "DocumentType"),
                ("N° DE DOCUMENTO", "DocumentNumber"),
                ("DIRECCIÓN", "Address"),
                ("TELÉFONO", "Phone"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateProvider")
            };

            return columnsProperties;
        }
        #endregion

        #region ColumnsWarehouses
        public static List<(string ColumnName, string PropertyName)> GetColumnsWarehouses()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateWarehouse")
            };

            return columnsProperties;
        }
        #endregion

        #region GetColumnsProducts
        public static List<(string ColumnName, string PropertyName)> GetColumnsProducts()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("CÓDIGO", "Code"),
                ("NOMBRE", "Name"),
                ("STOCK MÍNIMO", "StockMin"),
                ("STOCK MÁXIMO", "StockMax"),
                ("PRECIO DE VENTA", "UnitSalePrice"),
                ("CATEGORÍA", "Category"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateProduct")
            };

            return columnsProperties;
        }
        #endregion

        #region GetColumnsPurcharses
        public static List<(string ColumnName, string PropertyName)> GetColumnsPurcharses()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("PROVEEDOR", "Provider"),
                ("ALMACÉN", "Warehouse"),
                ("MONTO TOTAL", "TotalAmount"),
                ("FECHA DE COMPRA", "DateOfPurcharse"),
            };

            return columnsProperties;
        }
        #endregion

        #region GetColumnsClients
        public static List<(string ColumnName, string PropertyName)> GetColumnsClients()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE", "Name"),
                ("EMAIL", "Email"),
                ("TIPO DE DOCUMENTO", "DocumentType"),
                ("N° DE DOCUMENTO", "DocumentNumber"),
                ("DIRECCIÓN", "Address"),
                ("TELÉFONO", "Phone"),
                ("FECHA DE CREACIÓN", "AuditCreateDate"),
                ("ESTADO", "StateClient"),
            };

            return columnsProperties;
        }
        #endregion

        #region GetColumnsSales
        public static List<(string ColumnName, string PropertyName)> GetColumnsSales()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("COMPROBANTE", "VoucherDescription"),
                ("N° COMPROBANTE", "VoucherNumber"),
                ("CLIENTE", "Client"),
                ("MONTO TOTAL", "TotalAmount"),
                ("FECHA DE VENTA", "DateOfSale"),
            };

            return columnsProperties;
        }
        #endregion
    }
}