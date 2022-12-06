using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIterator
{
    public class PurchaseDetail
    {
        public int Id { get; }
        public int PurchaseId { get; }
        public string ProductName { get; }

        public PurchaseDetail(int id, int purchaseId, string productName)
        {
            Id = id;
            PurchaseId = purchaseId;
            ProductName = productName;
        }
    }
}
