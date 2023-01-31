using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFactory;

namespace UserFactoryUsingExcel
{
    public class UserFactoryUsingExcel : UserFactory.UserFactory
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
