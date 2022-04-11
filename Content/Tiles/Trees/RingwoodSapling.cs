﻿using Terraria.ObjectData;
using Terraria;
using Terraria.ModLoader;
using Terraria.Enums;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Contagion.Content.Particles;
using Microsoft.Xna.Framework.Graphics;

namespace Contagion.Content.Tiles.Trees
{
    public class RingwoodSapling : ModTile
    {
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorValidTiles = new int[] 
			{ 
				ModContent.TileType<ContagionGrass_Tile>() 
			};
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Sapling");
			AddMapEntry(new Color(44, 37, 18), name);
			
			DustType = ModContent.DustType<Particles.Dusts.RingwoodDust>();
			AdjTiles = new int[] 
			{ 
				TileID.Saplings 
			};
		}

        public override int SaplingGrowthType(ref int style)
        {
			style = 0;
			return ModContent.TileType<RingwoodSapling>();
        }

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

        public override void RandomUpdate(int i, int j)
        {
            if (WorldGen.genRand.Next(20) == 0)
            {
				bool playerNearby = WorldGen.PlayerLOS(i, j);
				bool growTree = WorldGen.GrowTree(i, j);
				if (playerNearby && growTree)
                {
					WorldGen.TreeGrowFXCheck(i, j);
                }				
            }
        }

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
				effects = SpriteEffects.FlipHorizontally;
		}

	}
}
