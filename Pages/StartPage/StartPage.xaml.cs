namespace OwnedGame.Pages.StartPage;

public partial class StartPage : ContentPage
{
    public StartPage(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		var vm = serviceProvider.GetService<StartPageVM>();

        BindingContext = vm;
    }
}