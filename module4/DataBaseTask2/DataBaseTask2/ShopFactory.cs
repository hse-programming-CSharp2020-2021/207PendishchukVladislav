using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class ShopFactory : IEntityFactory<Shop>
    {
        private static long _id = 1;

        private string _name;

        public string _city;

        public string _district;

        public string _country;

        public long _phoneNumber;

        public ShopFactory(string name, string city, string district, string country, long phoneNumber)
        {
            _name = name;
            _city = city;
            _district = district;
            _country = country;
            _phoneNumber = phoneNumber;
        }

        public Shop Instance => new Shop(_id++, _name, _city, _district, _country, _phoneNumber);
    }
}
