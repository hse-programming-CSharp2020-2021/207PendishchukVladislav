using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class GoodFactory : IEntityFactory<Good>
    {
        private static long _id = 0;

        private string _name;

        private long _shopId;

        private string _description;

        private string _category;

        public GoodFactory(string name, long shopId, string description, string category)
        {
            _name = name;
            _shopId = shopId;
            _description = description;
            _category = category;
        }

        public Good Instance => new Good(_id++, _name, _shopId, _description, _category);
    }
}
