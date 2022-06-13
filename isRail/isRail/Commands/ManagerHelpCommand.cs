using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class ManagerHelpCommand : CommandBase
    {
        public HelpWindow ManagerHelpWindow { get; set; } 

        public override void Execute(object parameter)
        {
            ManagerHelpWindow = new HelpWindow("Manager");
            ManagerHelpWindow.Show();
        } 
    }
}
