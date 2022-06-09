using isRail.Models;
using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class BuyTicketCommand : CommandBase
    {
        private Models.App _app { get; }
        private Ride _ride { get; set; }
        public static event Action TicketBoughtEvent;

        public BuyTicketCommand(Models.App app, Ride ride)
        {
            _app = app; 
            _ride = ride;
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite kupiti kartu?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                 _app.Client.BoughtTickets.Add(_ride);  
                new MessageBoxCustom("Uspešno ste kupili kartu.", MessageType.Success, MessageButtons.Ok).ShowDialog();
                TicketBoughtEvent?.Invoke();
            }
            else
                new MessageBoxCustom("Kupovina otkazana.", MessageType.Info, MessageButtons.Ok).ShowDialog();
        }
    }
}
