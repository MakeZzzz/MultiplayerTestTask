using UnityEngine;

namespace Objects
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _damage = 10;
        
        public Rigidbody2D GetRigidBody()
        {
            return _rigidbody;
        }

        public int GetDamageValue()
        {
            return _damage;
        }
    }
}