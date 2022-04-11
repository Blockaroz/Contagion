using Contagion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.TileItems
{
    public class Ringwood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ringwood");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Pitstone_Tile>());
        }

        public override void AddRecipes()
        {
            //CreateRecipe()
            //    .AddIngredient(ModContent.ItemType<Pitstone>(), 2)
            //    .AddTile(TileID.Furnaces)
            //    .Register();
        }
    }
}
