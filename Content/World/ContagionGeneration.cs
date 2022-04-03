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
				tasks.RemoveAt(EvilIndex);
            }
		}

        public override void PostUpdateWorld()
        {
            if (Main.keyState.IsKeyDown(Keys.D1) && !Main.oldKeyState.IsKeyDown(Keys.D1))
                GenerateChasmRing(80, Main.MouseWorld.ToTileCoordinates().X, (int)Main.MouseWorld.ToTileCoordinates().Y);
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
				direction.Y *= Main.rand.NextFloat(1f, 1.1f);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize * 0.9f), y + (int)(direction.Y * ringSize * 0.9f), 11, 5, Pitstone, addTile: true, overRide: true);
				WorldGen.TileRunner(x + (int)(direction.X * ringSize * 1.1f), y + (int)(direction.Y * ringSize * 1.1f), 11, 5, Pitstone, addTile: true, overRide: true);

				WorldUtils.Gen(new Point(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize)), new Shapes.Circle(10), new Actions.PlaceWall((ushort)PitstoneWall));

				if (WorldGen.genRand.Next(500) == 0)
					WorldGen.PlaceLiquid(x + (int)(direction.X * ringSize), y + (int)(direction.Y * ringSize), LiquidID.Water, 2);
			}

			//extend the top
			for (int i = 0; i < 5; i++)
            {
				Vector2 direction = ((MathHelper.TwoPi / 5 * i) + MathHelper.PiOver2).ToRotationVector2().RotatedBy(MathHelper.Pi);
				//WorldGen.TileRunner(x + (int)(direction.X * 10), y - (int)(direction.Y * 8) - ringSize - 15, 30, 15, Pitstone, addTile: true, overRide: true);
				WorldUtils.Gen(new Point(x + (int)(direction.X * 8), y - (int)(direction.Y * 7) - ringSize - 15), new Shapes.Slime(10), new Actions.PlaceWall((ushort)PitstoneWall));
				WorldUtils.Gen(new Point(x + (int)(direction.X * 8), y - (int)(direction.Y * 7) - ringSize - 15), new Shapes.Slime(10), new Actions.PlaceTile((ushort)Pitstone));
			}

			//dig out a ring
			for (int i = 0; i < 180; i++)
			{
				Vector2 direction = ((MathHelper.TwoPi / 180 * i) + MathHelper.PiOver2).ToRotationVector2();
				direction.Y *= Main.rand.NextFloat(1f, 1.1f);
				WorldGen.digTunnel(x + (direction.X * ringSize), y + (direction.Y * ringSize), 0, 0, 10, 3);
			}
			//dig out the entrance mound
			WorldGen.digTunnel(x, y - ringSize - 5, 0, -1f, 7, 8);
		}
	}
}
