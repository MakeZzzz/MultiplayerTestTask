using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using ExitGames.Client.Photon;
using Models;
using Photon.Pun;
using Player;
using SimpleEventBus.Disposables;
using UI.ViewsControllers;
using UnityEngine;

namespace Managers
{
    public class StateGameManager : MonoBehaviourPunCallbacks, IDisposable
    {
        [SerializeField] private GameOverViewController _gameOverViewController;
        [SerializeField] private PlayerViewController _playerViewController;

        private CompositeDisposable _subscriptions;
        private Dictionary<PlayerController, PlayerModel> _playerControllers;

        private bool _isGameState = true;

        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void Awake()
        {
            _playerControllers = new Dictionary<PlayerController, PlayerModel>();

            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<GameOverEvent>(ChangeGameState),
                EventStreams.Game.Subscribe<GetPlayerControllerEvent>(AddGameController)
            };
        }

        private void Start()
        {
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { "IsGameState", _isGameState } });
        }

        private void Update()
        {
            if (_isGameState)
            {
                _playerViewController.gameObject.SetActive(true);
                _gameOverViewController.gameObject.SetActive(false);
            }
            else
            {
                _playerViewController.gameObject.SetActive(false);
                _gameOverViewController.gameObject.SetActive(true);
                _gameOverViewController.Initialize(_playerControllers.First().Value);
            }
        }

        private void AddGameController(GetPlayerControllerEvent eventData)
        {
            _playerControllers.Add(eventData.PlayerController, eventData.PlayerModel);
        }
        
        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player player, Hashtable changedProps)
        {
            if (player != null && player.Equals(PhotonNetwork.LocalPlayer))
            {
                if (changedProps.ContainsKey("IsGameState"))
                {
                    _isGameState = (bool)changedProps["IsGameState"];
                }
            }
        }

        private void ChangeGameState(GameOverEvent eventData)
        {
            var playerController = eventData.PlayerController;

            if (_playerControllers.ContainsKey(playerController))
            {
                playerController.gameObject.SetActive(false);
                _playerControllers.Remove(playerController);
                PhotonNetwork.Destroy(playerController.gameObject);   
            }

            if (_playerControllers.Count == 1)
            {
                _isGameState = !_isGameState;
                PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable { { "IsGameState", _isGameState } });
            }
        }
    }
}