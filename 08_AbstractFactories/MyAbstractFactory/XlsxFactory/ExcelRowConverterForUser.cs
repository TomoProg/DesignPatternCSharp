using MyAbstractFactory.Factory;

namespace MyAbstractFactory.XlsxFactory
{
    internal class ExcelRowConverterForUser : RowConverter
    {
        public User Convert(object row)
        {
            // Excelの行オブジェクトに変換
            var _row = (ExcelRow)row;
            return new User(_row[0].Value, _row[1].Value);
        }
    }
}