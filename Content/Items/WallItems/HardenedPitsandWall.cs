using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace Contagion.Content.Items.WallItems
{
    public class HardenedPitsandWall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hardened Pitsand Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlacableWall((ushort)ModContent.WallType<Walls.HardenedPitsandWall_Wall>());
		}

		public override void AddRecipes()
		{
			CreateRecipe(4)
				.AddIngredient<TileItems.HardenedPitsand>()
				.AddTile(TileID.WorkBenches)
				.AddCondition(Recipe.Condition.InGraveyardBiome)
				.Register();
		}
	}
}
