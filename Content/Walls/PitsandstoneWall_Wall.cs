using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Contagion.Content.Walls
{
    public class PitsandstoneWall_Wall : ModWall
    {
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;

			DustType = ModContent.DustType<Particles.Dusts.PitsandDust>();
			ItemDrop = ModContent.ItemType<Items.WallItems.PitsandstoneWall>();

			AddMapEntry(new Color(30, 35, 34));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
