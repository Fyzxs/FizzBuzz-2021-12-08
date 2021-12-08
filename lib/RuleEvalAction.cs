namespace TddLikeYouMeanIt.lib
{
    public interface IRuleEvalAction
    {
        public Answer Act(TurnCount turnCount);
    }

    public sealed class AsString_RuleEvalAction : IRuleEvalAction
    {
        public Answer Act(TurnCount turnCount)
        {
            return new TurnCountAsStringAnswer(turnCount);
        }
    }

    public abstract class Base_RuleEvalAction : IRuleEvalAction
    {
        private readonly IRule _rule;
        private readonly Answer _answer;
        private readonly IRuleEvalAction _nextAction;

        protected Base_RuleEvalAction(IRule rule, Answer answer, IRuleEvalAction nextAction)
        {
            _rule = rule;
            _answer = answer;
            _nextAction = nextAction;
        }

        public Answer Act(TurnCount turnCount)
        {
            if (ShouldHandle(turnCount)) return _answer;

            return _nextAction.Act(turnCount);
        }

        private bool ShouldHandle(TurnCount turnCount) => _rule.Matches(turnCount);
    }

    public sealed class MultipleOfThree_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfThree_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfThreeRule(), new FizzAnswer(), nextAction) { }
    }

    public sealed class MultipleOfFive_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfFive_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfFiveRule(), new BuzzAnswer(), nextAction) { }
    }

    public sealed class MultipleOfThreeAndFive_RuleEvalAction : Base_RuleEvalAction
    {
        public MultipleOfThreeAndFive_RuleEvalAction(IRuleEvalAction nextAction) : base(new MultipleOfThreeAndFiveRule(), new FizzBuzzAnswer(), nextAction) { }
    }
}