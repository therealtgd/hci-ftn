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
        private readonly ClientReservedTicketsViewModel _clientReservedTicketsViewModel;
        
        public SwapFromToCommandReservedTicketsView(ClientReservedTicketsViewModel clientReservedTicketsViewModel)
        {
            _clientReservedTicketsViewModel = clientReservedTicketsViewModel;
        }
        public override void Execute(object parameter)
        {
            string tmp = _clientReservedTicketsViewModel.ToFilter;
            _clientReservedTicketsViewModel.ToFilter = _clientReservedTicketsViewModel.FromFilter;
            _clientReservedTicketsViewModel.FromFilter = tmp;
        }
    }
}
