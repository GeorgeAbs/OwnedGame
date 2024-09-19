using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OwnedGame.Services.NavigationService;
using OwnedGame.Services.RoundInfoService;

namespace OwnedGame.Pages.StartPage
{
    public partial class StartPageVM : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IRoundInfoService _roundInfoService;

        public StartPageVM(INavigationService navigationService, IRoundInfoService roundInfoService)
        {
            _navigationService = navigationService;
            _roundInfoService = roundInfoService;
        }

        [RelayCommand]
        public async Task NavigateToGameCreationPageAsync()
        {
            
            await _navigationService.NavigateToAsync($"{Routes.CREATION_GAME_PAGE_ROUTE}");
        }

        [RelayCommand]
        public async Task CreateInitialJsonAsync()
        {
            var result = await FolderPicker.Default.PickAsync();
            if (result.IsSuccessful)
            {
                DirectoryInfo dir = new DirectoryInfo(result.Folder.Path);

                var filesCount = dir.GetFiles("*owned_game*").Length;

                await _roundInfoService.WriteRoundToJsonAsync(new RoundInfoModel(), $"{result.Folder.Path}/owned_game_{filesCount++}.json");
            }
            
        }
    }
}
