using SimpleEventBus.Events;
using Weapons;

namespace Events
{
    public class GetWeaponSpawnedEvent : EventBase
    {
        public Weapon Weapon { get; }

        public GetWeaponSpawnedEvent(Weapon weapon)
        {
            Weapon = weapon;
        }
    }
}