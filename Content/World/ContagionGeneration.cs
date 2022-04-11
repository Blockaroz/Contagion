using Contagion.Content.Tiles;
using Contagion.Content.Walls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace Contagion.Content.World
{
	class ContagionGeneration : ModSystem
	{
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			int EvilIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Corruption"));

			if (ShiniesIndex != -1)
			{
			}
			if (EvilIndex != -1)
            {
				//tasks.RemoveAt(EvilIndex);
            }
		}

        public override void PostUpdateWorld()
        {
            if (Main.keyState.IsKeyDown(Keys.D1) && !Main.oldKeyState.IsKeyDown(Keys.D1))
                GenerateChasmRing(90, Main.MouseWorld.ToTileCoordinates().X, (int)Main.MouseWorld.ToTileCoordinates().Y);
        }

        private static int Pitstone => ModContent.TileType<Pitstone_Tile>();
		private static int PitstoneWall => ModContent.WallType<PitstoneWall_Wall>();

		private void GenerateContagionChasm(GenerationProgress progress)
        {
			
        }

		private void DigChasmTunnel(int x, int y)
        {

        }

		private void GenerateChasmRing(int ringSize, int x, int y)
        {
			//place circle
			for (int i = 0; i < 180; i++)
			{	
				Vector2 direction = ((MathHelper.TwoPi / 180 * i) + MathHelper.PiOver2).ToRotationVector2();
				direction.Y *= Main.rand.NextFloat(1f, 1.05f);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize * 0.9f), y + (int)(direction.Y * ringSize * 0.9f), 9, 6, Pitstone, addTile: true, overRide: true);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize * 1.1f), y + (int)(direction.Y * ringSize * 1.1f), 9, 6, Pitstone, addTile: true, overRide: true);

				WorldUtils.Gen(new Point(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize)), new Shapes.Circle(9), new Actions.PlaceWall((ushort)PitstoneWall));

				if (WorldGen.genRand.Next(100) == 0)
					WorldGen.PlaceLiquid(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize), LiquidID.Water, 128);
			}

			//extend the top
			WorldUtils.Gen(new Point(x, y - ringSize - 15), new Shapes.Slime(15, 1f, 1.2f), new Actions.PlaceWall((ushort)PitstoneWall));
			WorldUtils.Gen(new Point(x, y - ringSize - 15), new Shapes.Slime(15, 1f, 1.2f), new Actions.PlaceTile((ushort)Pitstone));

			//dig out a ring
			for (int i = 0; i < 180; i++)
			{
				Vector2 direction = ((MathHelper.TwoPi / 180 * i) + MathHelper.PiOver2).ToRotationVector2();
				direction.Y *= Main.rand.NextFloat(1f, 1.05f);
				WorldGen.digTunnel(x + (direction.X * ringSize), y + (direction.Y * ringSize), 0, 0, 7, 4);
			}
			//dig out the entrance mound
			WorldGen.digTunnel(x, y - ringSize - 8, 0, -2f, 12, 6, true);
		}
	}
}
