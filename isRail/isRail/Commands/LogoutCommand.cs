using isRail.ViewModels;
using isRail.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isRail.Commands
{
    public class LogoutCommand : CommandBase
    {
        private Models.App _app;

        public static event Action LogoutEvent;
        public LogoutCommand(Models.App app)
        {
            _app = app;
        }

        public override void Execute(object parameter)
        {
            bool? result = new MessageBoxCustom("Da li ste sigurni da želite da se odjavite?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (result.Value)
            {
                _app.Client = null;
                _app.Manager = null;
                LogoutEvent?.Invoke();
                _app.NavigationStore.CurrentViewModel = new LoginViewModel(_app);
            }
        }
    }
}
