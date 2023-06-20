using Models;
using Player;
using SimpleEventBus.Events;

namespace Events
{
    public class GetPlayerControllerEvent : EventBase
    {
        public PlayerController PlayerController { get; }
        public PlayerModel PlayerModel { get; }

        public GetPlayerControllerEvent(PlayerController playerController, PlayerModel playerModel)
        {
            PlayerController = playerController;
            PlayerModel = playerModel;
        }
    }
}