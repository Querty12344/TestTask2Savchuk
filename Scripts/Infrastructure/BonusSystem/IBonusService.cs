using System.Collections.Generic;

namespace Infrastructure.BonusSystem
{
    public interface IBonusService
    {
        int GetBonus();
        IEnumerable<int> GetRandomBonuses(int count);
    }
}