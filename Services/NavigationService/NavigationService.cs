namespace OwnedGame.Services.NavigationService
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null)
        {
            return routeParameters is not null
            ? Shell.Current.GoToAsync(new(route), routeParameters)
            : Shell.Current.GoToAsync(route);
        }

        public Task GoBackAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}
