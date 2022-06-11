using isRail.Models;
using System;

namespace isRail.ViewModels
{
    internal class TicketDetailsViewModel
    {
        private TicketDetails _ticket;

        public Client Client => _ticket.Client;
        public DateTime DateTimeBought => _ticket.DateTimeBought;

        public TicketDetailsViewModel(TicketDetails ticket)
        {
            _ticket = ticket;
        }
    }
}