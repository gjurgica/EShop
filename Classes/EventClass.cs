using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class EventClass:EventArgs
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public Place Place { get; set; }
        public Provider Provider { get; set; }
        public EventClass(string street,int number,Place place,Provider provider)
        {
            Street = street;
            Number = number;
            Place = place;
            Provider = provider;
        }
    }
}
