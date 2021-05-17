using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class SaleFactory : IEntityFactory<Sale>
    {
        private static long _id = 1;

        private long _buyerID;

        private long _shopID;

        private long _goodID;

        private long _amount;

        private decimal _price;

        public SaleFactory(long buyerID, long shopID, long goodID, long amount, decimal price)
        {
            _buyerID = buyerID;
            _shopID = shopID;
            _goodID = goodID;
            _amount = amount;
            _price = price;
        }

        public Sale Instance => new Sale(_id++, _buyerID, _shopID, _goodID, _amount, _price);
    }
}
