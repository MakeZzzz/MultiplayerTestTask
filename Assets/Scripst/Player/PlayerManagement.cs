using System;
using Events;
using Models;
using SimpleEventBus.Disposables;
using UnityEngine;
using Photon.Pun;

namespace Player
{
    public class PlayerManagement : MonoBehaviour, IDisposable
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private PlayerController _playerController;
    
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 2f;

        private FixedJoystick _joystick;
        private CompositeDisposable _subscriptions;

        public void Initialize(PlayerModel playerModel, FixedJoystick joystick)
        {
            _playerController.Initialize(playerModel, _photonView);
            _joystick = joystick;
            
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<GetShootOnButtonClickEvent>(Shoot)
            };
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }

        private void Update()
        {
            UserInput();
        }

        private void UserInput()
        {
            if (_photonView.IsMine)
            {
                var x = _joystick.Horizontal;
                var y = _joystick.Vertical;
                Move(x, y);
            }
        }
        private void Move(float x, float y)
        {
            var move = Time.deltaTime * _moveSpeed;
            var rotation = Time.deltaTime * _rotationSpeed;
            transform.Translate(Vector3.up * (move * y));
            transform.Rotate(new Vector3(0, 0, x) * (-90 * rotation));
        }
        private void Shoot(GetShootOnButtonClickEvent eventData)
        {
            _playerController.Shoot();
        }
    }
}