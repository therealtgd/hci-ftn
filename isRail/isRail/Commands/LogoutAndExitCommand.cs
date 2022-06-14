using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class LogoutAndExitCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite ugasiti aplikaciju?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
                System.Windows.Application.Current.Shutdown();
        }
    }
}
