using isRail.Stores;

namespace isRail.Services
{
    internal class NavigationService
    {
        private NavigationStore? navigationStore;
        private object p;

        public NavigationService(NavigationStore? navigationStore, object p)
        {
            this.navigationStore = navigationStore;
            this.p = p;
        }
    }
}