using GameState;
using Modules.Services.DI;
using UI.Money;

namespace GameData.Money
{
    public class MoneyMediator
    {
        private MoneyRepository _repository;

        [ServiceInject]
        public void Construct(MoneyRepository repository)
        {
            _repository = repository;
        }

        public void LoadData(GameContext context)
        {
            if (_repository.LoadMoney(out var dto) == false)
            {
                return;
            }

            var moneyStorage = context.GetService<MoneyStorage>();
            moneyStorage.SetMoney(dto.Money);
        }

        public void SaveData(GameContext context)
        {
            var moneyStorage = context.GetService<MoneyStorage>();
            var dto = new MoneyDTO
            {
                Money = moneyStorage.Money
            };
            
            _repository.SaveMoney(dto);
        }
    }
}
