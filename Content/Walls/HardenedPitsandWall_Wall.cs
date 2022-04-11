using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Contagion.Content.Walls
{
    public class HardenedPitsandWall_Wall : ModWall
    {
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;

			DustType = ModContent.DustType<Particles.Dusts.PitsandDust>();
			ItemDrop = ModContent.ItemType<Items.WallItems.PitsandstoneWall>();

			AddMapEntry(new Color(44, 51, 42));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
