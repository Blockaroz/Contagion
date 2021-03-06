using Contagion.Content.Particles;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Contagion.Content.Biomes;

namespace Contagion.Content.Tiles.Torches
{
    public class ContagionTorch_Tile : ModTile
    {
		private Asset<Texture2D> flameTexture;

		public override void SetStaticDefaults()
		{
			Main.tileLighted[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileNoAttach[Type] = true;
			Main.tileNoFail[Type] = true;
			Main.tileWaterDeath[Type] = true;
			TileID.Sets.FramesOnKillWall[Type] = true;
			TileID.Sets.DisableSmartCursor[Type] = true;
			TileID.Sets.Torch[Type] = true;

			ItemDrop = ModContent.ItemType<ContagionTorch>();
			DustType = ModContent.DustType<Particles.Dusts.ContagionFlameDust>();
			AdjTiles = new int[] { TileID.Torches };

			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);

			TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorLeft = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124 };
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorRight = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.Tree | AnchorType.AlternateTile, TileObjectData.newTile.Height, 0);
			TileObjectData.newAlternate.AnchorAlternateTiles = new[] { 124 };
			TileObjectData.addAlternate(2);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.StyleTorch);
			TileObjectData.newAlternate.AnchorWall = true;
			TileObjectData.addAlternate(0);
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Torch");
			AddMapEntry(new Color(253, 221, 3), name);

			if (!Main.dedServ)
				flameTexture = Mod.Assets.Request<Texture2D>("Content/Tiles/Torches/ContagionTorch_TileFlame");
		}

		public override float GetTorchLuck(Player player)
		{
			bool inContagion = Main.LocalPlayer.InModBiome(ModContent.GetInstance<ContagionSurface>()); //Main.LocalPlayer.InModBiome(ModContent.GetInstance<ContagionUnderground>())
			bool inContagionDesert = Main.LocalPlayer.InModBiome(ModContent.GetInstance<ContagionDesert>()); //Main.LocalPlayer.InModBiome(ModContent.GetInstance<ContagionDesertUG>())
			bool inContagionIce = Main.LocalPlayer.InModBiome(ModContent.GetInstance<ContagionDesert>());
			return inContagion || inContagionDesert || inContagionIce ? 1f : -0.1f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = Main.rand.Next(1, 3);

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			Tile tile = Main.tile[i, j];

			Vector3 light = new Color(154, 219, 32).ToVector3();
			if (tile.TileFrameX < 66)
			{
				r = light.X;
				g = light.Y;
				b = light.Z;
			}
		}

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = 0;

			if (WorldGen.SolidTile(i, j - 1))
			{
				offsetY = 2;

				if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
					offsetY = 4;
			}
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			int offsetY = 0;

			if (WorldGen.SolidTile(i, j - 1))
			{
				offsetY = 2;
				if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
					offsetY = 4;
			}

			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);

			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}

			ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)(uint)i);
			Color color = new Color(100, 100, 100, 0);
			int width = 20;
			int height = 20;
			var tile = Main.tile[i, j];
			int frameX = tile.TileFrameX;
			int frameY = tile.TileFrameY;

			for (int k = 0; k < 7; k++)
			{
				float xx = Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
				float yy = Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;

				spriteBatch.Draw(flameTexture.Value, new Vector2(i * 16 - (int)Main.screenPosition.X - (width - 16f) / 2f + xx, j * 16 - (int)Main.screenPosition.Y + offsetY + yy) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default, 1f, SpriteEffects.None, 0f);
			}
		}
	}
}
