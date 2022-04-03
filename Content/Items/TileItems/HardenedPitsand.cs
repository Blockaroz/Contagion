using Contagion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class HardenedPitsand : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<HardenedPitsand_Tile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<WallItems.HardenedPitsandWall>(4)
                .AddTile(TileID.WorkBenches)
                .AddCondition(Recipe.Condition.InGraveyardBiome)
                .Register();
        }
    }
}
