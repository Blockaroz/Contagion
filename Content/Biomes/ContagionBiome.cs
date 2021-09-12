using Contagion.Content.Biomes.Water;
using Contagion.Content.Tiles;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Biomes
{
    public class ContagionBiome : ModBiome
    {
        public override bool IsPrimaryBiome => true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion");
        }
        public override ModWaterStyle WaterStyle => Mod.Find<ModWaterStyle>("Contagion/ContagionWaterStyle");

        public override int Music => MusicID.Crimson;

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<ContagionBlockCounts>().contagionBlockCount >= 40;

            bool b2 = player.ZoneSkyHeight || player.ZoneOverworldHeight;
            return b1 && b2;
        }
    }

    public class ContagionBlockCounts : ModSystem
    {
        public int contagionBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            contagionBlockCount = tileCounts[ModContent.TileType<Pitstone_Tile>()];
        }
    }
}
