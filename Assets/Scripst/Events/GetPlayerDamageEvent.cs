using Objects;
using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class GetPlayerDamageEvent : EventBase
    {
        public PlayerModel PlayerModel { get; }
        public Bullet Bullet { get; }

        public GetPlayerDamageEvent(PlayerModel playerModel, Bullet bullet)
        {
            PlayerModel = playerModel;
            Bullet = bullet;
        }
    }
}