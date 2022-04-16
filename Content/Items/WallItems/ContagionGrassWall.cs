using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria;

namespace Contagion.Content.Items.WallItems
{
    public class ContagionGrassWall : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Contagion Grass Wall");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 400;
		}

		public override void SetDefaults()
		{
			Item.DefaultToPlacableWall((ushort)ModContent.WallType<Walls.ContagionGrassWall_Wall>());
		}
	}
}
