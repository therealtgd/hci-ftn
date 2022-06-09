using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class SwapFromToCommandReservedTicketsView : CommandBase
    {
        private readonly ClientMainViewModel _clientTicketPurchasingViewModel;
        
        public SwapFromToCommandReservedTicketsView(ClientMainViewModel clientTicketPurchasingViewModel)
        {
            _clientTicketPurchasingViewModel = clientTicketPurchasingViewModel;
        }
        public override void Execute(object parameter)
        {
            string tmp = _clientTicketPurchasingViewModel.ToFilter;
            _clientTicketPurchasingViewModel.ToFilter = _clientTicketPurchasingViewModel.FromFilter;
            _clientTicketPurchasingViewModel.FromFilter = tmp;
        }
    }
}
