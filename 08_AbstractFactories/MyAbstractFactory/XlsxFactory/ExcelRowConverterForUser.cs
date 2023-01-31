using MyAbstractFactory.Factory;

namespace MyAbstractFactory.XlsxFactory
{
    internal class ExcelRowConverterForUser : RowConverter
    {
        public User Convert(object row)
        {
            // Excelの行オブジェクトに変換
            var _row = (Excel.Row)row;
            var name = _row.GetCell(0).Value.ToString();
            var blood = _row.GetCell(1).Value.ToString();
            return new User(name, blood);
        }
    }
}