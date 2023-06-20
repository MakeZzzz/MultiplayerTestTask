using UnityEngine;

namespace Objects
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _value = 1;

        public int GetValue()
        {
            return _value;
        }
    }
}