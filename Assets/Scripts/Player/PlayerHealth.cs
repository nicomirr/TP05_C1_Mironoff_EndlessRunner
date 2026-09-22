using Game.Data;

namespace Game.Player
{
    public class PlayerHealth
    {
        private readonly int _maxHealth;

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

    }

}

