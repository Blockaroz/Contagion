using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

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
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 7;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createWall = ModContent.WallType<Walls.PitstoneWall_Wall>();
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
