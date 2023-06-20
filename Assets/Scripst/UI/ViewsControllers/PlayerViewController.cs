using Events;
using Models;
using UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ViewsControllers
{
    public class PlayerViewController : MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private Button _shootButton;
    
        private PlayerModel _playerModel;

        public void Initialize(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _playerView.Initialize(_playerModel.CountCoins,_playerModel.Health);
            _shootButton.onClick.AddListener(ShootButtonOnClick);
        }

        private void Update()
        {
            _playerView.Display(_playerModel.CountCoins,_playerModel.Health);
        }

        private void ShootButtonOnClick()
        {
            EventStreams.Game.Publish(new GetShootOnButtonClickEvent());
        }
    }
}