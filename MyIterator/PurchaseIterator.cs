using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    class PurchaseIterator : Iterator<PurchaseDetail>
    {
        private Purchase _purchase;
        private int index = 0;

        public PurchaseIterator(Purchase purchase)
        {
            _purchase = purchase;
        }

        public bool HasNext()
        {
            return _purchase.GetDetailLength() > index;
        }

        public PurchaseDetail Next()
        {
            var detail = _purchase.GetDetailAt(index);
            index++;
            return detail;
        }
    }
}
