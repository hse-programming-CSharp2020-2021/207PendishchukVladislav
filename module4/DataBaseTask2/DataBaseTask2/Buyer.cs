using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataBaseTask2
{
    [DataContract]
    class Buyer : IEntity
    {
        [DataMember]
        public long Id { private set; get; }
        [DataMember]
        public string Name { private set; get; }
        [DataMember]
        public string LastName { private set; get; }
        [DataMember]
        public string Address { private set; get; }
        [DataMember]
        public string City { private set; get; }
        [DataMember]
        public string District { private set; get; }
        [DataMember]
        public string Country { private set; get; }
        [DataMember]
        public long ZipCode { private set; get; }

        public Buyer(long id, string name, string lastName, string address, string city, string district, string country, long zipCode)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Address = address;
            City = city;
            District = district;
            Country = country;
            ZipCode = zipCode;
        }
    }
}
