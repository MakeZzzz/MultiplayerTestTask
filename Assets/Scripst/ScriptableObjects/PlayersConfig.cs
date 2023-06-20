using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayersConfig", menuName = "PlayersConfig")]
    public class PlayersConfig : ScriptableObject
    {
        public ConfigPlayerModel[] PlayerModels => _playerModels;

        [SerializeField] private ConfigPlayerModel[] _playerModels;
    }
}
