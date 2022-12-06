using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    class Purchase : Aggregator<PurchaseDetail>
    {
        public int Id { get; }
        public DateTime PurchaseDt { get; }
        private List<PurchaseDetail> _purchaseDetailList;

        public Purchase(int id, DateTime purchaseDt)
        {
            Id = id;
            PurchaseDt = purchaseDt;
            _purchaseDetailList = new List<PurchaseDetail>();
        }

        public void AddDetail(int id, string productName)
        {
            _purchaseDetailList.Add(
                new PurchaseDetail(id, this.Id, productName)
            );
        }

        public int GetDetailLength()
        {
            return _purchaseDetailList.Count;
        }

        public PurchaseDetail GetDetailAt(int index)
        {
            return _purchaseDetailList[index];
        }

        public Iterator<PurchaseDetail> CreateIterator()
        {
            return new PurchaseIterator(this);
        }
    }
}
