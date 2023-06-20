using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class ConfigPlayerModel
    {
        public string ColorName => _colorName;
        public Color Color => _color;
        public int Health => _health;
        public int CountCoins => _countCoins;
        
        [SerializeField] private string _colorName;
        [SerializeField] private Color _color;
        [SerializeField] private int _health;
        [SerializeField] private int _countCoins;
    }
}