using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles.Foliage
{
    public class RingwoodTree : ModTree
    {
        private static Mod Mod { get => ModContent.GetInstance<Contagion>(); }

        public override TreePaintingSettings TreeShaderSettings => new TreePaintingSettings
        {
            UseSpecialGroups = true,
            SpecialGroupMinimalHueValue = 11f / 72f,
            SpecialGroupMaximumHueValue = 0.25f,
            SpecialGroupMinimumSaturationValue = 0.88f,
            SpecialGroupMaximumSaturationValue = 1f
        };

        public override Asset<Texture2D> GetTexture() => Mod.Assets.Request<Texture2D>("Content/Tiles/Foliage/RingwoodTree");

        public override Asset<Texture2D> GetTopTextures() => Mod.Assets.Request<Texture2D>("Content/Tiles/Foliage/RingwoodTree_Tops");

        public override Asset<Texture2D> GetBranchTextures() => Mod.Assets.Request<Texture2D>("Content/Tiles/Foliage/RingwoodTree_Branches");

        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[] { ModContent.TileType<ContagionGrass_Tile>() };   
        }

        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return ModContent.TileType<RingwoodSapling>();
        }

        public override int DropWood() => ModContent.ItemType<Items.TileItems.Ringwood>();

        public override void SetTreeFoliageSettings(Tile tile, int xoffset, ref int treeFrame, ref int floorY, ref int topTextureFrameWidth, ref int topTextureFrameHeight)
        {
        }
    }
}
