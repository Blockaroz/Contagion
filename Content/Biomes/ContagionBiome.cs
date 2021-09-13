using Contagion.Content.Biomes.Water;
using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Graphics.Capture;
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
        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Contagion/ContagionWaterStyle");

        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Mushroom;

        public override int Music => MusicID.Crimson;

        public override string BestiaryIcon => "Contagion/Content/Biomes/IconEvilContagion";
        public override string BackgroundPath => "Contagion/Content/Biomes/ContagionMapBG";
        public override Color? BackgroundColor => new Color(30, 36, 27);

        public override bool IsBiomeActive(Player player)
        {
            bool b1 = ModContent.GetInstance<ContagionBlockCounts>().contagionBlockCount >= 300;
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
