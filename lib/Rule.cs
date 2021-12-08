using System.Linq;

namespace TddLikeYouMeanIt.lib
{
    public interface IRule
    {
        bool Matches(TurnCount turnCount);
    }

    public abstract class MultipleOfRule : IRule
    {
        private readonly int _multipleOf;

        protected MultipleOfRule(int multipleOf) => _multipleOf = multipleOf;

        public bool Matches(TurnCount turnCount) => turnCount % _multipleOf == 0;
    }

    public sealed class MultipleOfThreeRule : MultipleOfRule
    {
        public MultipleOfThreeRule() : base(3) { }
    }

    public sealed class MultipleOfFiveRule : MultipleOfRule
    {
        public MultipleOfFiveRule() : base(5) { }
    }

    public abstract class CompoundRule : IRule
    {
        private readonly IRule[] _rules;

        protected CompoundRule(params IRule[] rules) => _rules = rules;

        public bool Matches(TurnCount turnCount) => _rules.All(it => it.Matches(turnCount));
    }

    public sealed class MultipleOfThreeAndFiveRule : CompoundRule
    {
        public MultipleOfThreeAndFiveRule()
            : base(new MultipleOfThreeRule(), new MultipleOfFiveRule()) { }
    }
}