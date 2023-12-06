using System.Collections.Generic;
using DiceComponents;
using Infrastructure.BonusSystem;

namespace Infrastructure.GamePool
{
    internal class GamePool : IGamePool
    {
        public DiceFacade Dice { get; set; }
        public List<Bonus> Bonuses { get; set; }
    }
}