namespace Game.Core
{
    public interface IPlayerStateReader
    {
        public PlayerState CurrentState { get; }
    }

}

