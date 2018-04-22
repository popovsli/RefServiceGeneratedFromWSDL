using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RefServices
{
    public class TrackedFault
    {
        public TrackedFault(Guid id, string details, DateTime dateTime)
        {
            _trackingID = id;
            _dateTime = dateTime;
            _details = details;
        }

        public TrackedFault()
        {

        }

        Guid _trackingID;
        string _details;
        DateTime _dateTime;

        [XmlElement]
        public Guid TrackingId
        {
            get { return _trackingID; }
            set { _trackingID = value; }
        }

        [XmlElement]
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }
        [XmlElement]
        public DateTime DateAndTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

    }
}
