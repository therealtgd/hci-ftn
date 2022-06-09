using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class SwapFromToCommandPurchaseView : CommandBase
    {
        private readonly ClientTicketPurchasingViewModel _clientTicketPurchasingViewModel;
        
        public SwapFromToCommandPurchaseView(ClientTicketPurchasingViewModel clientTicketPurchasingViewModel)
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
