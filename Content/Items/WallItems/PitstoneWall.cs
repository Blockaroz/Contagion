using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace Contagion.Content.Items.WallItems
{
    public class PitstoneWall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pitstone Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlacableWall((ushort)ModContent.WallType<Walls.PitstoneWall_Wall>());
		}

		public override void AddRecipes()
		{
			CreateRecipe(4)
				.AddIngredient<TileItems.Pitstone>()
				.AddTile(TileID.WorkBenches)
				.AddCondition(Recipe.Condition.InGraveyardBiome)
				.Register();
		}
	}
}
