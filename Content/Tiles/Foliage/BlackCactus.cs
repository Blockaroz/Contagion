using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles.Foliage
{
    public class BlackCactus : ModCactus
    {
        public override Asset<Texture2D> GetTexture() => ModContent.Request<Texture2D>($"{nameof(Contagion)}/Content/Tiles/Foliage/BlackCactus");

        public override Asset<Texture2D> GetFruitTexture() => ModContent.Request<Texture2D>($"{nameof(Contagion)}/Content/Tiles/Foliage/BlackCactusFruit");

        public override void SetStaticDefaults()
        {
            GrowsOnTileId = new int[] { ModContent.TileType<Pitsand_Tile>() };
        }
    }
}
