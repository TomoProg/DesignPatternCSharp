using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstractFactory.XlsxFactory
{
    internal class Excel
    {
        public List<Row> Rows { get; set; } = new List<Row>();

        internal class Row
        {
            private List<Cell> _cells = new List<Cell>();

            public void Add(Cell cell)
            {
                _cells.Add(cell);
            }

            public Cell GetCell(int index)
            {
                return _cells[index];
            }
        }

        internal class Cell
        {
            public object Value { get; set; }
            public Cell(object value)
            {
                Value = value;
            }
        }

        internal static Excel FileRead(string filepath)
        {
            return CreateMockExcel(); // 本当はファイルから読み込むけど、実装困難なので、モックを返す
        }

        private static Excel CreateMockExcel()
        {
            var result = new Excel();
            var r1 = new Row();
            r1.Add(new Cell("suzuki"));
            r1.Add(new Cell("A"));
            result.Rows.Add(r1);

            var r2 = new Row();
            r2.Add(new Cell("saito"));
            r2.Add(new Cell("B"));
            result.Rows.Add(r2);
            return result;
        }
    }
}
