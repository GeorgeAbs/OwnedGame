namespace OwnedGame.Pages.GameCreationPage.QuestionActors
{
    public abstract class QuestionActorBase
    {
        public RoundCell RoundCell { get; private set; }

        public GameCreationPageVM GameCreationPageVM { get; private set; }

        protected bool _isQuestionFinished = false;

        public QuestionActorBase(RoundCell roundCell, GameCreationPageVM gameCreationPageVM)
        {
            RoundCell = roundCell;
            GameCreationPageVM = gameCreationPageVM;
        }

        public virtual void ActQuestion()
        {
            if (_isQuestionFinished) return;
        }

        public virtual void InitializeQuestion()
        {
            GameCreationPageVM.IsTableVisible = false;
            GameCreationPageVM.IsQuestionVisible = true;
            GameCreationPageVM.Question = "";
            GameCreationPageVM.ImageSource = null;
            RoundCell.Color = GameCreationPageVM.ClickedColor!;
        }

        public void FinishQuestion()
        {
            GameCreationPageVM.IsTableVisible = true;
            GameCreationPageVM.IsQuestionVisible = false;
            _isQuestionFinished = true;
        }
    }
}
