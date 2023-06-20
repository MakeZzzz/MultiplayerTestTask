using System.Collections.Generic;
using Models;
using Photon.Pun;
using Player;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class PlayerSpawnerSystem : MonoBehaviour
    {
        [SerializeField] private PlayerManagement _playerPrefab;
        [SerializeField] private List<Transform> _playersPositions;
        
        private readonly List<Transform> _occupiedPositions = new();
        public void SpawnPlayer(PlayerModel playerModel, FixedJoystick joystick)
        {
            Transform randomPosition;
            do
            { 
                randomPosition = _playersPositions[Random.Range(0, _playersPositions.Count)];
            } 
            while (_occupiedPositions.Contains(randomPosition));
            _occupiedPositions.Add(randomPosition);
            
            var newPlayer = PhotonNetwork.Instantiate(_playerPrefab.gameObject.name, randomPosition.position, quaternion.identity);
            newPlayer.gameObject.GetComponent<PlayerManagement>().Initialize(playerModel, joystick);
        }
    }
}