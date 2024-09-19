namespace OwnedGame.Services.NavigationService
{
    public interface INavigationService
    {
        public Task NavigateToAsync(string route, IDictionary<string, object>? routeParameters = null);

        public Task GoBackAsync();
    }
}
