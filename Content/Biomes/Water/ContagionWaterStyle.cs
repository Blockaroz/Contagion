using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Contagion.Content.Biomes.Water
{
    public class ContagionWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("Contagion/ContagionWaterfallStyle").Slot;

        public override int GetDropletGore() => Find<ModGore>("Contagion/ContagionWaterGore").Type;

        public override int GetSplashDust() => DustType<ContagionSplashDust>();

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.15f;
            g = 0.9f;
            b = 0.365f;
        }

        public override Color BiomeHairColor() => Color.DarkOliveGreen;
    }
}
