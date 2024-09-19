using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OwnedGame.Pages.GameCreationPage.QuestionActors;
using OwnedGame.Services.RoundInfoService;
using System.Collections.ObjectModel;

namespace OwnedGame.Pages.GameCreationPage
{
    public partial class GameCreationPageVM : ObservableObject
    {
        private readonly IRoundInfoService _roundInfoService;

        [ObservableProperty]
        private RoundInfoModel _roundInfoModel = null!;

        [ObservableProperty]
        public ObservableCollection<RoundRow> _roundRows = [];

        [ObservableProperty]
        public ObservableCollection<Competitor> _competitors = [];

        [ObservableProperty]
        private Color _notClickedColor = null!;

        [ObservableProperty]
        private Color _clickedColor = null!;

        [ObservableProperty]
        private RoundModel _roundModel = null!;

        private bool _isGameStarted = false;

        private int _selectedRowNumber = 0;

        [ObservableProperty]
        private bool _isTableVisible = true;

        [ObservableProperty]
        private bool _isQuestionVisible = false;

        [ObservableProperty]
        private string _question = "";

        [ObservableProperty]
        private ImageSource? _imageSource;

        private QuestionActorBase? _questionActor;

        public GameCreationPageVM(IRoundInfoService roundInfoService)
        {
            _roundInfoService = roundInfoService;
        }

        public async Task OnAppearing()
        {
            await InitializeAsync();
        }

        public async Task InitializeAsync()
        {
            var result = await FilePicker.Default.PickAsync();

            if (result == null) throw new ArgumentNullException(nameof(result));

            var model = await _roundInfoService.LoadRoundFromJsonAsync(result.FullPath);

            RoundInfoModel = model;

            var row0 = CreateRoundRow(model.Row0);
            var row1 = CreateRoundRow(model.Row1);
            var row2 = CreateRoundRow(model.Row2);
            var row3 = CreateRoundRow(model.Row3);
            var row4 = CreateRoundRow(model.Row4);
            var row5 = CreateRoundRow(model.Row5);

            RoundRows.Add(row0);
            RoundRows.Add(row1);
            RoundRows.Add(row2);
            RoundRows.Add(row3);
            RoundRows.Add(row4);
            RoundRows.Add(row5);

            var roundModel = new RoundModel(model.RowsHeight, [row0, row1, row2, row3, row4, row5], model.Competitors);

            RoundModel = roundModel;

            ClickedColor = new Color(model.ClickedCellsColor.R, model.ClickedCellsColor.G, model.ClickedCellsColor.B);
            NotClickedColor = new Color(model.NotClickedCellsColor.R, model.NotClickedCellsColor.G, model.NotClickedCellsColor.B);

            foreach (var competitor in model.Competitors)
            {
                Competitors.Add(new Competitor(competitor));
            }
        }

        [RelayCommand]
        public void ProceedClick()
        {
            if (_selectedRowNumber < 6)
            {
                RoundRows.ElementAt(_selectedRowNumber).IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell1.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell2.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell3.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell4.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell5.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell6.IsEnable = true;
                RoundRows.ElementAt(_selectedRowNumber).Cell7.IsEnable = true;

                _selectedRowNumber++;

                if (_selectedRowNumber == 6) _isGameStarted = true;
            }

            if (!_isGameStarted) return;

            _questionActor?.ActQuestion();
        }

        
        public void ProceedCellClick(RoundCell cell)
        {
            if (!_isGameStarted) return;

            cell.CellClicked -= ProceedCellClick;
            cell.Color = new Color(RoundInfoModel.NotClickedCellsColor.R, RoundInfoModel.NotClickedCellsColor.G, RoundInfoModel.NotClickedCellsColor.B);
            cell.Price = "";

            IsTableVisible = false;
            IsQuestionVisible = true;

            switch (cell.Type)
            {
                case RoundInfoCellType.SimpleQuestion:
                    _questionActor = new SimpleQuestionActor(cell, this);
                    _questionActor.InitializeQuestion();
                    break;
                case RoundInfoCellType.DogInBag:
                    _questionActor = new DogInBoxQuestionActor(cell, this);
                    _questionActor.InitializeQuestion();
                    break;
                case RoundInfoCellType.Meme:
                    _questionActor = new MemeQuestionActor(cell, this);
                    _questionActor.InitializeQuestion();
                    break;
            }
        }

        private RoundCell CreateRoundCell(RoundInfoCell roundInfoCell)
        {
            var newCell = new RoundCell(roundInfoCell.IsEnable,
                roundInfoCell.Type,
                roundInfoCell.Question!,
                roundInfoCell.Price,
                new Color(RoundInfoModel.NotClickedCellsColor.R, RoundInfoModel.NotClickedCellsColor.G, RoundInfoModel.NotClickedCellsColor.B),
                roundInfoCell.Picture1,
                roundInfoCell.Picture2);

            newCell.CellClicked += ProceedCellClick;

            return newCell;
        }

        private RoundRow CreateRoundRow(RoundInfoRow roundInfoRow)
        {
            return new RoundRow(new Color(RoundInfoModel.NotClickedCellsColor.R, RoundInfoModel.NotClickedCellsColor.G, RoundInfoModel.NotClickedCellsColor.B),
                roundInfoRow.IsEnable,
                roundInfoRow.Topic,
                CreateRoundCell(roundInfoRow.Cell1),
                CreateRoundCell(roundInfoRow.Cell2),
                CreateRoundCell(roundInfoRow.Cell3),
                CreateRoundCell(roundInfoRow.Cell4),
                CreateRoundCell(roundInfoRow.Cell5),
                CreateRoundCell(roundInfoRow.Cell6),
                CreateRoundCell(roundInfoRow.Cell7));
        }

        
    }
}
