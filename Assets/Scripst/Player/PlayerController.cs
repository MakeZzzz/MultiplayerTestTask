using Objects;
using Events;
using Models;
using Photon.Pun;
using UnityEngine;
using Weapons;


namespace Player
{
    public class PlayerController : MonoBehaviour, IPunObservable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Weapon _weapon;
        private PhotonView _photonView;
        private PlayerModel _playerModel;

        
        public void Initialize(PlayerModel playerModel, PhotonView photonView)
        {
            _playerModel = playerModel;
            _photonView = photonView;

            if (_photonView.IsMine)
            {
                _spriteRenderer.color = _playerModel.Color;
                EventStreams.Game.Publish(new GetPlayerControllerEvent(this, playerModel));
            }
        }
        
        public void Shoot()
        {
            _weapon.Shoot();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_playerModel);
            }
            else
            {
                _playerModel = (PlayerModel) stream.ReceiveNext();
                _spriteRenderer.color = _playerModel.Color;
            }
        }

        private void OnTriggerEnter2D(Collider2D otherCollider)
        {
            if (otherCollider.gameObject.CompareTag("Bullet"))
            {
                var bullet = otherCollider.GetComponent<Bullet>();
                EventStreams.Game.Publish(new GetPlayerDamageEvent(_playerModel, bullet));
                СheckHealth();
            }
            if (otherCollider.gameObject.CompareTag("Coin"))
            {
                var coin = otherCollider.GetComponent<Coin>();
                EventStreams.Game.Publish(new GetCoinEvent(_playerModel, coin));
            }
        }
        
        private void СheckHealth()
        {
            if (_playerModel.Health <= 0)
            {
                EventStreams.Game.Publish(new GameOverEvent(this));
            }
        }
    }
}