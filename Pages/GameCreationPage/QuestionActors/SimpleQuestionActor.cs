namespace OwnedGame.Pages.GameCreationPage.QuestionActors
{
    public class SimpleQuestionActor : QuestionActorBase
    {

        public SimpleQuestionActor(RoundCell roundCell, GameCreationPageVM gameCreationPageVM) : base(roundCell, gameCreationPageVM)
        {
        }

        public override void ActQuestion()
        {
            base.ActQuestion();

            FinishQuestion();
        }

        public override void InitializeQuestion()
        {
            base.InitializeQuestion();

            GameCreationPageVM.Question = RoundCell.Question;
        }
    }
}
