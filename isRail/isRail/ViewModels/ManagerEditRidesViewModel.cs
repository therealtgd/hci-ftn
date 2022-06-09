namespace isRail.ViewModels
{
    public class ManagerEditRidesViewModel : ViewModelBase
    {
        public Models.App App { get; set; }

        public ManagerEditRidesViewModel(Models.App app)
        {
            App = app;
        }
    }
}