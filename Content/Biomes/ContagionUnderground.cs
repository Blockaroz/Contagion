using Contagion.Content.Biomes.Water;
using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.Graphics.Capture.CaptureBiome;

namespace Contagion.Content.Biomes
{
    public class ContagionUnderground : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion");  
        }

        //public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Contagion/Content/Biomes/Backgrounds/ContagionUndergroundBackground");;

        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Contagion/ContagionWaterStyle");

        public override TileColorStyle TileColorStyle => TileColorStyle.Jungle;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Mharadium");

        public override string BestiaryIcon => "Contagion/Content/Biomes/IconContagionUG";
        public override string BackgroundPath => "Contagion/Content/Biomes/ContagionMapBackground";
        public override Color? BackgroundColor => new(30, 36, 27);

        public override bool IsBiomeActive(Player player)
        {
            bool biomeExists = ModContent.GetInstance<ContagionBlockCounts>().contagionCountTotal >= 300;
            bool correctZone = (player.ZoneDirtLayerHeight || player.ZoneRockLayerHeight) && !player.ZoneSnow;
            return biomeExists && correctZone;
        }
    }
}
