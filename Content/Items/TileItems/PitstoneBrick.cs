using Contagion.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class PitstoneBrick : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<PitstoneBrick_Tile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Pitstone>(), 2)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
