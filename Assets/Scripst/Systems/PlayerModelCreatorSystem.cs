using Models;
using ScriptableObjects;
using UnityEngine;

namespace Systems
{
    public class PlayerModelCreatorSystem : MonoBehaviour
    {
        [SerializeField] private PlayersConfig _playersConfig;

        public PlayerModel CreatePlayerModel()
        {
            var randomIndex = Random.Range(0, _playersConfig.PlayerModels.Length);
            var colorName = _playersConfig.PlayerModels[randomIndex].ColorName;
            var color = _playersConfig.PlayerModels[randomIndex].Color;
            var health = _playersConfig.PlayerModels[randomIndex].Health;
            var coins = _playersConfig.PlayerModels[randomIndex].CountCoins;
            var model = new PlayerModel(colorName, color, health, coins);

            return model;
        }
    }
}