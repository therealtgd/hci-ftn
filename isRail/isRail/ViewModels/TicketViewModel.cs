using isRail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace isRail.ViewModels
{
    public class TicketViewModel : ViewModelBase
    {
        private Models.App _app { get; set; }   
        private readonly Ride _ride;

        private readonly ObservableCollection<TicketDetailsViewModel> _tickets;
        public ICollectionView TicketDetailsCollectionView { get; }
        public RideViewModel RideViewModel => new RideViewModel(_ride, _app);
        

        public TicketViewModel(Models.App app, Ride ride, List<TicketDetails> tickets)
        {
            _app = app;
            _ride = ride;
            _tickets = new ObservableCollection<TicketDetailsViewModel>();
            foreach (var ticket in tickets)
                _tickets.Add(new TicketDetailsViewModel(ticket));
            TicketDetailsCollectionView = CollectionViewSource.GetDefaultView(_tickets);

        }
    }
}
