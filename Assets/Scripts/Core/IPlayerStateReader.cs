using Game.Core;
using UnityEngine;

public interface IPlayerStateReader
{
    public PlayerState CurrentState { get; }
}
