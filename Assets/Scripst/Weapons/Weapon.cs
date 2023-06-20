using Events;
using Systems;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _bulletVelocity = 8f;
        [SerializeField] private Transform _muzzle;
        
        private PoolSystem _poolSystem;
        private void Start()
        {
            EventStreams.Game.Publish(new GetWeaponSpawnedEvent(this));
        }
        
        public void Initialize(PoolSystem poolSystem)
        {
            _poolSystem = poolSystem;
        }
        
        public void Shoot()
        {
            var bullet = _poolSystem.GetBullet();
            bullet.transform.position = _muzzle.transform.position;
            bullet.GetRigidBody().velocity = transform.right * _bulletVelocity;
        }
       
    }
}
    

    