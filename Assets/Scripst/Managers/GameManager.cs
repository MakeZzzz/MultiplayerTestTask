using ExitGames.Client.Photon;
using Photon.Pun;
using Models;
using Systems;
using UI;
using UI.ViewsControllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField] private PlayerSpawnerSystem _playerSpawnerSystem;
        [SerializeField] private PlayerModelCreatorSystem _playerModelCreatorSystem;
        [SerializeField] private PlayerViewController _playerViewController;
        [SerializeField] private CoinsSpawnerSystem _coinsSpawnerSystem;
        [SerializeField] private FixedJoystick _fixedJoystick;

        private PlayerDamageSystem _playerDamageSystem;
        private PlayerIncomeSystem _playerIncomeSystem;
        
        
        private void Start()
        {
            PhotonPeer.RegisterType(typeof(PlayerModel), 5, PhotonSerializeSystem.SerializePlayerModel, PhotonSerializeSystem.DeserializePlayerModel);

            var playerModel = _playerModelCreatorSystem.CreatePlayerModel();
            _playerSpawnerSystem.SpawnPlayer(playerModel, _fixedJoystick);
            _playerViewController.Initialize(playerModel);
            _playerDamageSystem = new PlayerDamageSystem();
            _playerIncomeSystem = new PlayerIncomeSystem();
            
            _coinsSpawnerSystem.Spawn();
        }

        private void OnDestroy()
        {
            _playerIncomeSystem.Dispose();
            _playerDamageSystem.Dispose();
        }
    }
}