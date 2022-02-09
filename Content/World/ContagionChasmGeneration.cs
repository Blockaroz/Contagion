using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Contagion.Content.World
{
	class ContagionChasmGeneration : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			int EvilIndex = tasks.FindIndex(genpass => genpass.Name.Equals(""));

			if (ShiniesIndex != -1)
			{
			}
		}

        private static int Pitstone => ModContent.TileType<Pitstone_Tile>();
		private static int PitstoneWall => WallID.Stone;//ModContent.WallType<>();

		
		private void GenerateContagionChasm(GenerationProgress progress)
        {
			
        }

		private void GenerateChasmRing(int x, int y)
        {
			int ringSize = 80;

			//place circle
			for (int i = 0; i < 180; i++)
			{	
				Vector2 direction = ((MathHelper.TwoPi / 180 * i) + MathHelper.PiOver2).ToRotationVector2();
				direction.X *= Main.rand.NextFloat(1f, 1.1f);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize), 50, ringSize / 4, Pitstone, addTile: true, overRide: true);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize * 1.2f), y + (int)(direction.Y * ringSize * 1.2f), 15, ringSize / 3, Pitstone, addTile: true, overRide: true);

				WorldUtils.Gen(new Point(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize)), new Shapes.Circle(15), new Actions.PlaceWall((ushort)PitstoneWall));
			}
			//extend the bottom
			WorldGen.TileRunner(x, y + (int)(ringSize * 1.2f), 50, 15, Pitstone, addTile: true, overRide: true);
			WorldUtils.Gen(new Point(x, y + (int)(ringSize * 1.2f)), new Shapes.Circle(15, 10), new Actions.PlaceWall((ushort)PitstoneWall));

			//extend the top
			WorldGen.TileRunner(x, y - (int)(ringSize * 1.3f), 70, 20, Pitstone, addTile: true, overRide: true);
			WorldUtils.Gen(new Point(x, y - (int)(ringSize * 1.2f)), new Shapes.Circle(20, 24), new Actions.PlaceWall((ushort)PitstoneWall));

			//dig out a ring
			for (int i = 0; i < 180; i++)
			{
				Vector2 direction = ((MathHelper.TwoPi / 180 * i) + MathHelper.PiOver2).ToRotationVector2();
				direction.X *= Main.rand.NextFloat(1f, 1.1f);
				WorldGen.digTunnel(x + (direction.X * ringSize), y + (direction.Y * ringSize), 0, 0, ringSize / 4, 3);
			}

			//dig a small pit
			WorldGen.digTunnel(x - 1, y + (ringSize * 1.15f), 0.66f, -0.33f, 20, 4, true);
			WorldGen.digTunnel(x + 1, y + (ringSize * 1.15f), -0.66f, -0.33f, 20, 4, false);

			//dig out the entrance mound
			WorldGen.digTunnel(x, y - (ringSize * 1.1f), 0, -1f, 15, 12);
		}
	}
}
