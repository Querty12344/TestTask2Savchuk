using DiceComponents;
using Effects;
using Infrastructure.BonusSystem;
using Infrastructure.UI.Elements;

namespace Infrastructure.AssetsManagement
{
    public interface IAssetProvider
    {
        DiceFacade Dice { get; }
        Hud Hud { get; }
        Effect BonusEffect { get; }
        Effect TossingEffect { get; }
        Effect ResultEffect { get; }
        Bonus Bonus { get; }
        BonusAddingText BonusAddingText { get; }
        void LoadAssets();
    }
}