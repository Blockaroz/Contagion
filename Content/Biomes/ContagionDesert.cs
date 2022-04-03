using Contagion.Content.Biomes.Water;
using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using static Terraria.Graphics.Capture.CaptureBiome;

namespace Contagion.Content.Biomes
{
    public class ContagionDesert : ModBiome
    {
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeHigh;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion Desert");
        }

        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Contagion/ContagionDesertSurfaceBackground");

        public override ModWaterStyle WaterStyle => ModContent.Find<ModWaterStyle>("Contagion/ContagionWaterStyle");

        public override TileColorStyle TileColorStyle => TileColorStyle.Corrupt;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Mharadium");

        public override string BestiaryIcon => "Contagion/Content/Biomes/IconContagionDesert";
        public override string BackgroundPath => "Contagion/Content/Biomes/ContagionDesertMapBackground";
        public override Color? BackgroundColor => new(30, 36, 27);

        internal float ContagionBiomeInfluence;

        public override bool IsBiomeActive(Player player)
        {
            bool biomeExists = ModContent.GetInstance<ContagionBlockCounts>().contagionCountDesert >= 300;
            bool correctZone = player.ZoneOverworldHeight && !player.ZoneBeach;
            return biomeExists && correctZone;
        }
    }
}
