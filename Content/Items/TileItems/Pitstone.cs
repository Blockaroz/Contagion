using Contagion.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class Pitstone : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Pitstone_Tile>());
        }
    }
}
