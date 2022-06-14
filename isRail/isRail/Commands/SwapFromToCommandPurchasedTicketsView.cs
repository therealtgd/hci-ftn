using isRail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    internal class SwapFromToCommandPurchasedTicketsView : CommandBase
    {
        private readonly ClientPurchasedTicketsViewModel _clientPurchasedTicketsViewModel;
        
        public SwapFromToCommandPurchasedTicketsView(ClientPurchasedTicketsViewModel clientPurchasedTicketsViewModel)
        {
            _clientPurchasedTicketsViewModel = clientPurchasedTicketsViewModel;
        }
        public override void Execute(object parameter)
        {
            string tmp = _clientPurchasedTicketsViewModel.ToFilter;
            _clientPurchasedTicketsViewModel.ToFilter = _clientPurchasedTicketsViewModel.FromFilter;
            _clientPurchasedTicketsViewModel.FromFilter = tmp;
        }
    }
}
