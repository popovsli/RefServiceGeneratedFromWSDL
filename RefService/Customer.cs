using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RefServices
{
    public class Customer
    {
        [XmlElement("ID",Order = 1)]
        public int ID { get; set; }

        [XmlElement("Name", Order = 2)]
        public string FirstName { get; set; }

        [XmlElement("Last_Name", Order = 3)]
        public string LastName { get; set; }
    }
}
