namespace OwnedGame.Pages.GameCreationPage.QuestionActors
{
    public class MemeQuestionActor : QuestionActorBase
    {
        private int _attempt = 0;

        public MemeQuestionActor(RoundCell roundCell, GameCreationPageVM gameCreationPageVM) : base(roundCell, gameCreationPageVM)
        {
        }

        public override void ActQuestion()
        {
            base.ActQuestion();

            switch (_attempt)
            {
                case 0:
                    if (File.Exists(RoundCell.Picture2))
                    {
                        GameCreationPageVM.ImageSource = ImageSource.FromStream(() => new MemoryStream(File.ReadAllBytes(RoundCell.Picture2)));
                    }
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
