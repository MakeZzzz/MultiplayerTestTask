using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentScoreCoin;
        [SerializeField] private Slider _healthBar;
        public void Initialize(int score, float health)
        {
            _healthBar.maxValue = health;
            Display(score,health);
        }
        public void Display(int score,float health)
        {
            _healthBar.value = health;
            _currentScoreCoin.text = score.ToString();
            
        }
    }
}