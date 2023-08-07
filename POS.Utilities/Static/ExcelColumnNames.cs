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
    }
}