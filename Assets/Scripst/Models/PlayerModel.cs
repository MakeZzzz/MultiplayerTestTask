using UnityEngine;

namespace Models
{
    public class PlayerModel
    {
        public string ColorName { get; }
        public Color Color { get; }
        public int Health { get; set; }
        public int CountCoins { get; set; }
        public PlayerModel(string colorName,Color color, int health, int countCoins)
        {
            ColorName = colorName;
            Color = color;
            Health = health;
            CountCoins = countCoins;
        }
    }
}
