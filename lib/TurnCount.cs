namespace TddLikeYouMeanIt.lib
{
    public abstract class TurnCount : ToSystemType<int> { }

    public sealed class IntTurnCount : TurnCount
    {
        private readonly int _origin;

        public IntTurnCount(int origin) => _origin = origin;

        protected override int AsSystemType() => _origin;
    }
}