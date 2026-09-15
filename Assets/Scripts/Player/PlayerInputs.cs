using UnityEngine;

public class PlayerInputs
{
    private readonly GameControls _playerControls;
    
    public PlayerInputs()
    {
        _playerControls = new GameControls();
        _playerControls.Enable();
    }

    public void Deinitialize()
    {
        _playerControls.Disable();
    }
}
