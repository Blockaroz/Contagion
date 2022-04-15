using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;   

namespace Contagion.Content.Tiles.Trees
{
    public class RingwoodTree : ModTree
    {
        private static Mod Mod { get => ModContent.GetInstance<Contagion>(); }

        public override int DropWood() => ModContent.ItemType<Items.TileItems.Ringwood>();

        public override int GrowthFXGore() => GoreID.TreeLeaf_GemTreeEmerald;

        public override int CreateDust() => ModContent.DustType<Particles.Dusts.RingwoodDust>();

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) => Mod.Assets.Request<Texture2D>("Content/Tiles/Trees/RingwoodTree_Branches").Value;

        public override Texture2D GetTexture() => Mod.Assets.Request<Texture2D>("Content/Tiles/Trees/RingwoodTree").Value;

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset)
        {
            frameWidth = 82;
            frameHeight = 94;
            xOffsetLeft = 32;
            yOffset = 14;
            return Mod.Assets.Request<Texture2D>("Content/Tiles/Trees/RingwoodTree_Tops").Value;
        }
    }
}
