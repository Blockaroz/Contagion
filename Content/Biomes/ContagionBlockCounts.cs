using Contagion.Content.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Biomes
{
    public class ContagionBlockCounts : ModSystem
    {
        public int contagionCountTotal;
        public int contagionCountRegular;
        public int contagionCountIce;
        public int contagionCountDesert;
        public int sunflowers;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            contagionCountRegular = tileCounts[ModContent.TileType<ContagionGrass_Tile>()] + tileCounts[ModContent.TileType<Pitstone_Tile>()];
            contagionCountIce = tileCounts[ModContent.TileType<SeaGreenIce_Tile>()];
            contagionCountDesert = tileCounts[ModContent.TileType<Pitsand_Tile>()] + tileCounts[ModContent.TileType<Pitsandstone_Tile>()] + tileCounts[ModContent.TileType<HardenedPitsand_Tile>()];
            sunflowers = 5 * tileCounts[TileID.Sunflower];

            contagionCountTotal = contagionCountRegular + contagionCountIce + contagionCountDesert - sunflowers;
        }
    }
}
