using Objects;
using Models;
using SimpleEventBus.Events;

namespace Events
{
    public class GetCoinEvent : EventBase
    {
        public PlayerModel PlayerModel { get; }
        public Coin Coin { get; }

        public GetCoinEvent(PlayerModel playerModel, Coin coin)
        {
            PlayerModel = playerModel;
            Coin = coin;
        }
    }
}