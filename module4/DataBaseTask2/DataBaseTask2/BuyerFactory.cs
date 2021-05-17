using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseTask2
{
    class BuyerFactory : IEntityFactory<Buyer>
    {
        private static long _id = 1;

        private string _name;

        private string _lastName;

        private string _address;

        private string _city;

        private string _district;

        private string _country;

        private long _zipCode;

        public BuyerFactory(string name, string lastName, string address, string city, string district, string country, long zipCode)
        {
            _name = name;
            _lastName = lastName;
            _address = address;
            _city = city;
            _district = district;
            _country = country;
            _zipCode = zipCode;
        }

        public Buyer Instance => new Buyer(_id++, _name, _lastName, _address, _city, _district, _country, _zipCode);
    }
}
