using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAbstractFactory.Factory;

namespace MyAbstractFactory.XlsxFactory
{
    public class UserFactoryUsingExcel : Factory.UserFactory
    {
        public Parser createParser()
        {
            return new ExcelParser();
        }

        public RowConverter createRowConverter()
        {
            return new ExcelRowConverterForUser();
        }
    }
}
