using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataBaseTask2
{
    [DataContract]
    class Sale : IEntity
    {
        [DataMember]
        public long Id { private set; get; }
        [DataMember]
        public long BuyerID { private set; get; }
        [DataMember]
        public long ShopID { private set; get; }
        [DataMember]
        public long GoodID { private set; get; }
        [DataMember]
        public long Amount { private set; get; }
        [DataMember]
        public decimal Price { private set; get; }

        public Sale(long id, long buyerID, long shopID, long goodID, long amount, decimal price)
        {
            Id = id;
            BuyerID = buyerID;
            ShopID = shopID;
            GoodID = goodID;
            Amount = amount;
            Price = price;
        }
    }
}
