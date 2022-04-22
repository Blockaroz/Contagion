using Contagion.Content.Particles;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles
{
    public class HardenedPitsand_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Conversion.HardenedSand[Type] = true;
            TileID.Sets.isDesertBiomeSand[Type] = true;
            TileID.Sets.ForAdvancedCollision.ForSandshark[Type] = true;
            TileID.Sets.CanBeClearedDuringGeneration[Type] = true;

            DustType = ModContent.DustType<Particles.Dusts.PitsandDust>();
            SoundType = SoundID.Dig;
            ItemDrop = ModContent.ItemType<HardenedPitsand>();
            AddMapEntry(new Color(34, 40, 31));
        }
    }
}
