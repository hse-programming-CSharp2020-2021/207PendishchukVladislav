using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataBaseTask2
{
    [DataContract]
    class Shop : IEntity
    {
        [DataMember]
        public long Id { private set; get; }
        [DataMember]
        public string Name { private set; get; }
        [DataMember]
        public string City { private set; get; }
        [DataMember]
        public string District { private set; get; }
        [DataMember]
        public string Country { private set; get; }
        [DataMember]
        public long PhoneNumber { private set; get; }

        public Shop(long id, string name, string city, string district, string country, long phoneNumber)
        {
            Id = id;
            Name = name;
            City = city;
            District = district;
            Country = country;
            PhoneNumber = phoneNumber;
        }
    }
}
