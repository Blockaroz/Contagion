using Contagion.Content.Biomes;
using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ModLoader;

namespace Contagion
{
    public class ContagionPlayer : ModPlayer
    {
        public bool ZoneContagion
        {
            get
            {
                bool inRegular = Player.InModBiome(ModContent.GetInstance<ContagionSurface>());
                bool inUnderground = Player.InModBiome(ModContent.GetInstance<ContagionUnderground>());
                bool inDesert = Player.InModBiome(ModContent.GetInstance<ContagionDesert>());
                bool inDesertUnderground = true;//Player.InModBiome(ModContent.GetInstance<ContagionDesertUnderground>());
                bool inIce = true;//Player.InModBiome(ModContent.GetInstance<ContagionIce>());
                return inRegular || inIce || inDesert || inUnderground || inDesertUnderground;
            }
            private set { }
        }

        public override void ResetEffects()
        {
            ZoneContagion = false;
        }
    }
}
