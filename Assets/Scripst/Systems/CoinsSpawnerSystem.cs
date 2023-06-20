using System.Collections.Generic;
using Objects;
using Photon.Pun;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems
{
    public class CoinsSpawnerSystem : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private int _minCoinsCount = 4;
        [SerializeField] private List<Transform>  _coinsPositions;
        [SerializeField] private PhotonView _photonView;
        
        private readonly List<Transform> _occupiedPositions = new();
        private int _maxCoinsCount;
       
        private void Start()
        {
            _maxCoinsCount = _coinsPositions.Count;
        }

        public void Spawn()
        {
            var _coinsToSpawn = Random.Range(_minCoinsCount, _maxCoinsCount+1);
            if (_photonView.AmOwner)
            {
                for (int i = 0; i < _coinsToSpawn; i++)
                {
                    Transform randomPosition;
                    do
                    { 
                        randomPosition = _coinsPositions[Random.Range(0, _coinsPositions.Count)];
                    } 
                    while (_occupiedPositions.Contains(randomPosition));
                    _occupiedPositions.Add(randomPosition);
                    PhotonNetwork.Instantiate(_coinPrefab.gameObject.name, randomPosition.position, quaternion.identity);
                }
                
            }
        }
    }
}