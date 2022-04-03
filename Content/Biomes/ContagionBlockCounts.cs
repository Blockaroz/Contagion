using Contagion.Content.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace Contagion.Content.Biomes
{
    public class ContagionBlockCounts : ModSystem
    {
        public int contagionCountTotal;
        public int contagionCountRegular;
        public int contagionCountDesert;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            contagionCountRegular = tileCounts[ModContent.TileType<ContagionGrass_Tile>()] + tileCounts[ModContent.TileType<Pitstone_Tile>()];
            contagionCountDesert = tileCounts[ModContent.TileType<Pitsand_Tile>()] + tileCounts[ModContent.TileType<Pitsandstone_Tile>()] + tileCounts[ModContent.TileType<HardenedPitsand_Tile>()];
            contagionCountTotal = contagionCountRegular + contagionCountDesert;
        }
    }
}
