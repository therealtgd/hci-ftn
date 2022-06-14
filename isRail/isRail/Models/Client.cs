using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Models
{
    public class Client : User
    {
        public List<Ride> BoughtTickets { get; set; }
        public List<Ride> ReservedTickets { get; set; }

        public Client(string username, string password) : base(username, password)
        {
            BoughtTickets = new List<Ride>();
            ReservedTickets = new List<Ride>();
        }
    }
}
