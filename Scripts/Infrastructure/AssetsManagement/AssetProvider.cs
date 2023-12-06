using Constants;
using DiceComponents;
using Effects;
using Infrastructure.BonusSystem;
using Infrastructure.UI.Elements;
using UnityEngine;

namespace Infrastructure.AssetsManagement
{
    public class AssetProvider : IAssetProvider
    {
        public DiceFacade Dice { get; private set; }
        public Hud Hud { get; private set; }
        public Effect BonusEffect { get; private set; }
        public Effect TossingEffect { get; private set; }
        public Effect ResultEffect { get; private set; }
        public Bonus Bonus { get; private set; }
        public BonusAddingText BonusAddingText { get; private set; }

        public void LoadAssets()
        {
            Hud = Resources.Load<Hud>(AssetPath.Hud);
            Bonus = Resources.Load<Bonus>(AssetPath.Bonus);
            Dice = Resources.Load<DiceFacade>(AssetPath.Dice);
            BonusEffect = Resources.Load<Effect>(AssetPath.BonusEffect);
            TossingEffect = Resources.Load<Effect>(AssetPath.TossingEffect);
            ResultEffect = Resources.Load<Effect>(AssetPath.ResultEffect);
            BonusAddingText = Resources.Load<BonusAddingText>(AssetPath.BonusText);
        }
    }
}