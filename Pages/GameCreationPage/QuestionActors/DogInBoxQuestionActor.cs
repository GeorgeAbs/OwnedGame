namespace OwnedGame.Pages.GameCreationPage.QuestionActors
{
    public class DogInBoxQuestionActor : QuestionActorBase
    {
        private int _attempt = 0;
        public DogInBoxQuestionActor(RoundCell roundCell, GameCreationPageVM gameCreationPageVM) : base(roundCell, gameCreationPageVM)
        {
        }

        public override void ActQuestion()
        {
            base.ActQuestion();

            switch (_attempt)
            {
                case 0:
                    GameCreationPageVM.ImageSource = null;
                    GameCreationPageVM.Question = RoundCell.Question;
                    break;
                case 1:
                    FinishQuestion();
                    break;
            }
            _attempt++;


        }

        public override void InitializeQuestion()
        {
            base.InitializeQuestion();

            if (File.Exists(RoundCell.Picture1))
            {
                GameCreationPageVM.ImageSource = ImageSource.FromStream(() => new MemoryStream(File.ReadAllBytes(RoundCell.Picture1)));
            }
        }
    }
}
