using Game.Data;
using Game.Events;


namespace Game.Player
{
    public class PlayerHealth
    {
        private readonly int _maxHealth;
        public int MaxHealth => _maxHealth;

        private int _currentMaxHealth;
        public int CurrentMaxHealth => _currentMaxHealth;

        private int _currentHealth;
        public int CurrentHealth => _currentHealth;

        public PlayerHealth(PlayerConfigSo data)
        {
            _maxHealth = data.MaxHealth;
            _currentMaxHealth = data.MaxInitialHealth;
            _currentHealth = _currentMaxHealth;
        }

        public void SubstractHealth()
        {
            _currentHealth--;
        }

        public void AddHealth()
        {
            if (_currentHealth >= _maxHealth)
            {
                _currentHealth = _maxHealth;
                return;
            }                       

            _currentHealth++;
            PlayerEvents.RaisePlayerHealed();
        }
    }

}

