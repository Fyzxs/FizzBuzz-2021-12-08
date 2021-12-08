namespace TddLikeYouMeanIt.lib
{
    public interface IFizzBuzz
    {
        Answer Turn(TurnCount source);
    }

    public sealed class FizzBuzz : IFizzBuzz
    {
        private readonly IRuleEvalAction _action;

        public FizzBuzz() : this(
            new MultipleOfThreeAndFive_RuleEvalAction(
                new MultipleOfFive_RuleEvalAction(
                    new MultipleOfThree_RuleEvalAction(
                        new AsString_RuleEvalAction())))
        )
        { }

        private FizzBuzz(IRuleEvalAction action) => _action = action;

        public Answer Turn(TurnCount source) => _action.Act(source);
    }
}