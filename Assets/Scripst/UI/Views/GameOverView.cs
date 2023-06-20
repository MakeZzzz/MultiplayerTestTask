using TMPro;
using UnityEngine;

namespace UI.Views
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _winner;
        [SerializeField] private TMP_Text _countCoins;

        public void Display(string colorName, string coins)
        {
            _winner.text = "Win " + colorName;
            _countCoins.text = "collected " + coins + " coins";
        }
    }
}