using CommunityToolkit.Mvvm.ComponentModel;

namespace OwnedGame.Pages.GameCreationPage
{
    public partial class Competitor : ObservableObject
    {
        [ObservableProperty]
        public string _name;

        [ObservableProperty]
        public string _score = "0";

        public Competitor(string name)
        {
            this._name = name;
        }
    }
}
