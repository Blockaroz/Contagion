using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Contagion.Content.Walls
{
    public class ContagionGrassWall_Wall : ModWall
    {
		public override void SetStaticDefaults()
		{
			Main.wallHouse[Type] = false;

			DustType = ModContent.DustType<Particles.Dusts.ContagionFoliage1>();

			AddMapEntry(new Color(48, 66, 26));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}
	}
}
