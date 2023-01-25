using System.Collections.Generic;
using MyAbstractFactory.Factory;

namespace MyAbstractFactory.XlsxFactory
{
    internal class ExcelParser : Parser
    {
        public List<object> Parse(string filepath)
        {
            // Excelファイルを読み込んで、行オブジェクトを返す
            // List<object>に変換する必要ありか
            return Excel.FileRead(filepath).Rows;
        }
    }
}