using System.Collections.Generic;
using System.Linq;
using UserFactory;

namespace UserFactoryUsingExcel
{
    internal class ExcelParser : Parser
    {
        public List<object> Parse(string filepath)
        {
            // Excelファイルを読み込んで、行オブジェクトを返す
            var excel = Excel.FileRead(filepath);
            var rows = Excel.FileRead(filepath).Rows;

            // List<object>に変換する
            // object型にしないといけないのがなんだか・・・
            return rows.Select(x => (object)x).ToList();
        }
    }
}