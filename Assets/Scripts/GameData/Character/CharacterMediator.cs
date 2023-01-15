using Core.Components.Abstract;
using GameState;
using Modules.Services.DI;
using Services;

namespace GameData.Character
{
    public class CharacterMediator
    {
        private CharacterRepository _repository;

        [ServiceInject]
        public void Construct(CharacterRepository repository)
        {
            _repository = repository;
        }

        public void LoadData(GameContext context)
        {
            if (_repository.LoadStats(out var data) == false)
            {
                return;
            }

            var character = context.GetService<CharacterService>().GetCharacter();
            character.Get<IHitPointsValueComponent>().SetValue(data.HitPoints);
            character.Get<IDamageValueComponent>().SetValue(data.Damage);
            character.Get<IMoveSpeedValueComponent>().SetValue(data.MoveSpeed);
        }

        public void SaveData(GameContext context)
        {
            var character = context.GetService<CharacterService>().GetCharacter();
            var data = new CharacterData()
            {
                HitPoints = character.Get<IHitPointsValueComponent>().GetValue(),
                Damage = character.Get<IDamageValueComponent>().GetValue(),
                MoveSpeed = character.Get<IMoveSpeedValueComponent>().GetValue()
            };
            
            _repository.SaveStats(data);
        }
    }
}
