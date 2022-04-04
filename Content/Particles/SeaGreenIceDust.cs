using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Contagion.Content.Particles
{
    public class SeaGreenIceDust : ModDust
    {
        public override void SetStaticDefaults()
        {
            UpdateType = DustID.Ice;
        }
    }
}