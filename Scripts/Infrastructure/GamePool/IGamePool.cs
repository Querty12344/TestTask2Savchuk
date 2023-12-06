using System.Collections.Generic;
using DiceComponents;
using Infrastructure.BonusSystem;

namespace Infrastructure.GamePool
{
    public interface IGamePool
    {
        DiceFacade Dice { get; set; }
        List<Bonus> Bonuses { get; set; }
    }
}