namespace OwnedGame.Pages.GameCreationPage;

public partial class GameCreationPage : ContentPage
{
    private readonly GameCreationPageVM _vm;

    public GameCreationPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		_vm = serviceProvider.GetService<GameCreationPageVM>()!;

        BindingContext = _vm;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _vm.OnAppearing();
    }
}