using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class ClientHelpCommand : CommandBase
    {
        public HelpWindow ClientHelpWindow { get; set; }
        public override void Execute(object parameter)
        {
            ClientHelpWindow = new HelpWindow("Client");
            ClientHelpWindow.Show();
        }
    }
}
