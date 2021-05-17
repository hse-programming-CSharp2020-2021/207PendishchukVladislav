using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DataBaseTask2
{
    [DataContract]
    class Good : IEntity
    {
        [DataMember]
        public long Id { private set; get; }
        [DataMember]
        public string Name { private set; get; }
        [DataMember]
        public long ShopId { private set; get; }
        [DataMember]
        public string Description { private set; get; }
        [DataMember]
        public string Category { private set; get; }

        public Good(long id, string name, long shopId, string description, string category)
        {
            Id = id;
            Name = name;
            ShopId = shopId;
            Description = description;
            Category = category;
        }
    }
}
