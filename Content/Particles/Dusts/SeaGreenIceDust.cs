using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Contagion.Content.Particles.Dusts
{
    public class SeaGreenIceDust : ModDust
    {
        public override void SetStaticDefaults()
        {
            UpdateType = DustID.Ice;
        }
    }
}