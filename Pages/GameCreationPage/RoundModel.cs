using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OwnedGame.Services.RoundInfoService;

namespace OwnedGame.Pages.GameCreationPage
{
    public partial class RoundModel : ObservableObject
    {
        [ObservableProperty]
        public int rowsHeight;

        [ObservableProperty]
        public List<RoundRow> rows;

        [ObservableProperty]
        public List<string> competitors;

        public RoundModel(int rowsHeight, List<RoundRow> rows, List<string> competitors)
        {
            this.rowsHeight = rowsHeight;
            this.rows = rows;
            this.competitors = competitors;
        }
    }

    public partial class RoundRow : ObservableObject
    {
        [ObservableProperty]
        public bool isEnable;

        [ObservableProperty]
        public string topic;

        [ObservableProperty]
        public Color baseColor;

        [ObservableProperty]
        public RoundCell cell1;
        [ObservableProperty]
        public RoundCell cell2;
        [ObservableProperty]
        public RoundCell cell3;
        [ObservableProperty]
        public RoundCell cell4;
        [ObservableProperty]
        public RoundCell cell5;
        [ObservableProperty]
        public RoundCell cell6;
        [ObservableProperty]
        public RoundCell cell7;

        public RoundRow(Color baseColor, bool isEnable, string topic, RoundCell cell1, RoundCell cell2, RoundCell cell3, RoundCell cell4, RoundCell cell5, RoundCell cell6, RoundCell cell7)
        {
            this.baseColor = baseColor;
            this.isEnable = isEnable;
            this.topic = topic;
            this.cell1 = cell1;
            this.cell2 = cell2;
            this.cell3 = cell3;
            this.cell4 = cell4;
            this.cell5 = cell5;
            this.cell6 = cell6;
            this.cell7 = cell7;
        }
    }

    public partial class RoundCell : ObservableObject
    {
        [ObservableProperty]
        public bool isEnable;

        public RoundInfoCellType Type { get; set; }

        public string Question { get; set; }

        [ObservableProperty]
        public string price;

        [ObservableProperty]
        public Color color;

        public string? Picture1 { get; set; } = null;

        public string? Picture2 { get; set; } = null;

        public RoundCell(bool isEnable, RoundInfoCellType type, string question, string price, Color color, string? picture1, string? picture2)
        {
            this.isEnable = isEnable;
            Type = type;
            Question = question;
            this.price = price;
            this.color = color;
            Picture1 = picture1;
            Picture2 = picture2;
        }

        [RelayCommand]
        public void CellClick(RoundCell roundCell)
        {
            CellClicked?.Invoke(roundCell);
        }

        public delegate void RoundCellEventHandler(RoundCell roundCell);
        public event RoundCellEventHandler? CellClicked;
    }
}
