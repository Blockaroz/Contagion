using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace Contagion.Content.Items.WallItems
{
    public class PitsandstoneWall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pitsandstone Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlacableWall((ushort)ModContent.WallType<Walls.PitsandstoneWall_Wall>());
		}

		public override void AddRecipes()
		{
			CreateRecipe(4)
				.AddIngredient<TileItems.Pitsandstone>()
				.AddTile(TileID.WorkBenches)
				.AddCondition(Recipe.Condition.InGraveyardBiome)
				.Register();
		}
	}
}
