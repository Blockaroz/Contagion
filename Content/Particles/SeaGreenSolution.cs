using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Particles
{
    public class SeaGreenSolution : ModDust
    {
        public override void SetStaticDefaults() => UpdateType = DustID.Clentaminator_Green;

        public override Color? GetAlpha(Dust dust, Color lightColor) => new Color(255, 255, 255, 0);
    }
}