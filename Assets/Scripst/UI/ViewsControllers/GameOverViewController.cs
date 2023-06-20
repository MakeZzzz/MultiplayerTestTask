using Models;
using UI.Views;
using UnityEngine;

namespace UI.ViewsControllers
{
    public class GameOverViewController : MonoBehaviour
    {
        [SerializeField] private GameOverView _gameOverView;

        public void Initialize(PlayerModel playerModel)
        {
            _gameOverView.Display( playerModel.ColorName, playerModel.CountCoins.ToString());
        }
    }
}