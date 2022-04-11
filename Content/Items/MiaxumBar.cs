using Contagion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items
{
    public class MiaxumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<MiaxumBar_Tile>());
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<MiaxumOre>(3)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}
