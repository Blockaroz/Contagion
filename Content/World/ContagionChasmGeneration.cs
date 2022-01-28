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
		public static bool JustPressed(Keys key)
		{
			return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		}

        public override void PostUpdateWorld()
        {
			//if (JustPressed(Keys.D1))
			//	GenerateRingChasm((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
		}

		private int Pitstone => ModContent.TileType<Pitstone_Tile>();
		private int PitstoneWall => WallID.ObsidianBackEcho;//ModContent.WallType<>();

		private void InfectRegion(int x, int y)
		{

		}

		private List<Point> colonyPositions = new List<Point>();

		private void GenerateRingChasm(int x, int y)
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

			//spawn colonies
			for (int i = 0; i < WorldGen.genRand.Next(16, 21); i++)
			{
				Vector2 colonyPosition = new Vector2(x, y) + ((MathHelper.TwoPi * WorldGen.genRand.NextFloat()).ToRotationVector2() * ringSize);
				if (Main.rand.NextBool())
                {
					//tunnel
					colonyPosition *= 1.2f;
					colonyPositions.Add(colonyPosition.ToPoint());
				}
                else
                {
					colonyPosition *= Main.rand.NextFloat(0.5f, 0.8f);
					colonyPositions.Add(colonyPosition.ToPoint());
				}
			}

			//DigColonyHoles(colonyPositions);
		}

		private void DigColonyHoles(List<Point> points)
        {
			//place
			for (int i = 0; i < points.Count; i++)
				WorldUtils.Gen(points[i], new Shapes.Circle(8), new Actions.SetTile((ushort)Pitstone));
			//dig
			for (int j = 0; j < points.Count; j++)
				WorldGen.digTunnel(points[j].X, points[j].Y, 0, 0, 4, 8);
			//place colony
		}
	}
}
