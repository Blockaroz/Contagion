using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Contagion.Content.Items.WallItems
{
    public class PitstoneBrickWall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pitstone Brick Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlacableWall((ushort)ModContent.WallType<Walls.PitstoneBrickWall_Wall>());
		}

		public override void AddRecipes()
		{
			CreateRecipe(4)
				.AddIngredient<TileItems.Pitstone>()
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
