using Player;
using SimpleEventBus.Events;

namespace Events
{
    public class GameOverEvent : EventBase
    {
        public PlayerController PlayerController { get; }

        public GameOverEvent(PlayerController playerController)
        {
            PlayerController = playerController;
        }
    }
}