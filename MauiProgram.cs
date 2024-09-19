using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using OwnedGame.Pages.GameCreationPage;
using OwnedGame.Pages.StartPage;
using OwnedGame.Services.NavigationService;
using OwnedGame.Services.RoundInfoService;

namespace OwnedGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(FileSystem.Current);
            builder.Services.AddSingleton(Preferences.Default);
            builder.Services.AddSingleton(SecureStorage.Default);

            builder.Services.AddTransient<INavigationService, NavigationService>();
            builder.Services.AddTransient<IRoundInfoService, RoundInfoService>();

            AddPage<StartPage, StartPageVM>(builder.Services, Routes.START_PAGE_ROUTE);
            AddPage<GameCreationPage, GameCreationPageVM>(builder.Services, Routes.CREATION_GAME_PAGE_ROUTE);

#if DEBUG
    		//builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static IServiceCollection AddPage<TPage, TViewModel>(IServiceCollection services, string route) where TPage : Page where TViewModel : ObservableObject
        {
            services
                .AddTransient<TPage>()
                .AddTransient<TViewModel>();

            Routing.RegisterRoute(route, typeof(TPage));

            return services;
        }

        private static IServiceCollection AddView<TView, TViewModel>(IServiceCollection services) where TView : ContentView where TViewModel : ObservableObject
        {
            services
                .AddTransient<TView>()
                .AddTransient<TViewModel>();

            return services;
        }
    }
}
