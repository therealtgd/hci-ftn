using isRail.Models;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class ReserveTicketCommand : CommandBase
    {
        private Models.App _app { get; }
        private Ride _ride { get; set; }
        public static event Action TicketReservedEvent;

        public ReserveTicketCommand(Models.App app, Ride ride)
        {
            _app = app;
            _ride = ride;
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite rezervisati kartu?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                _app.Client.ReservedTickets.Add(_ride);
                new MessageBoxCustom("Uspešno ste rezervisali kartu.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                TicketReservedEvent?.Invoke();

            }
            else
                new MessageBoxCustom("Rezervacija otkazana.", MessageType.Info, MessageButtons.Ok).ShowDialog();

        }
    }
}
