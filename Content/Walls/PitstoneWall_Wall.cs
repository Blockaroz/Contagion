using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Contagion.Content.Walls
{
    public class PitstoneWall_Wall : ModWall
    {
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;

			DustType = ModContent.DustType<Particles.PitstoneDust>();
			ItemDrop = ModContent.ItemType<Items.WallItems.PitstoneWall>();

			AddMapEntry(new Color(15, 16, 13));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
