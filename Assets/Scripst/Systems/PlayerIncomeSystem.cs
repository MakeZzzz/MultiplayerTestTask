using System;
using Events;
using SimpleEventBus.Disposables;

namespace Systems
{
    public class PlayerIncomeSystem : IDisposable
    {
        private readonly CompositeDisposable _subscriptions;

        public PlayerIncomeSystem()
        {
            _subscriptions = new CompositeDisposable
            {
                EventStreams.Game.Subscribe<GetCoinEvent>(IncreasePlayerIncome)
            };
        }
        
        private void IncreasePlayerIncome(GetCoinEvent eventData)
        {
            eventData.PlayerModel.CountCoins += eventData.Coin.GetValue();
            UnityEngine.Object.Destroy(eventData.Coin.gameObject);
        }
        
        public void Dispose()
        {
            _subscriptions?.Dispose();
        }
    }
}