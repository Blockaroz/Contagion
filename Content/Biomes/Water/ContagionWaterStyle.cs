using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Contagion.Content.Biomes.Water
{
    public class ContagionWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle() => Find<ModWaterfallStyle>("Contagion/ContagionWaterfallStyle").Slot;

        public override int GetDropletGore() => GoreType<Gores.ContagionWaterGore>();

        public override int GetSplashDust() => DustType<ContagionSplashDust>();

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 0.15f;
            g = 0.9f;
            b = 0.365f;
        }

        public override Color BiomeHairColor() => Color.DarkOliveGreen;

        public override Asset<Texture2D> GetRainTexture() => Mod.Assets.Request<Texture2D>("Content/Biomes/Water/ContagionRain");

        public override byte GetRainVariant() => (byte)Main.rand.Next(3);
    }
}
