using Game.Core;

public interface IPlayerStateChanger
{   
    public bool TryChangeState(PlayerState newState);
}
