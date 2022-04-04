using Contagion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class SeaGreenIce : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Green Ice");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<SeaGreenIce_Tile>());
        }
    }
}
