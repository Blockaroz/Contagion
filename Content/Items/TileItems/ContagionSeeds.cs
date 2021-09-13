using Contagion.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class ContagionSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion Seeds");
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ContagionGrass_Tile>(), 0);
        }

        public override bool? UseItem(Player player)
        {

            return true;
        }
    }
}
