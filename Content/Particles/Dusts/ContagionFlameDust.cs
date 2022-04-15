using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Contagion.Content.Particles.Dusts
{
    public class ContagionFlameDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity.Y = Main.rand.Next(-10, 6) * 0.1f;
            dust.velocity.X *= 0.3f;
            dust.scale *= 0.77f;
            //dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            if (!dust.noGravity)
                dust.velocity.Y += 0.05f;

            dust.scale *= 0.96f;
            if (dust.scale < 0.1f)
                dust.active = false;

            float strength = dust.scale * 1.4f;
            if (strength > 1f)
                strength = 1f;

            if (!dust.noLightEmittence)
                Lighting.AddLight(dust.position, new Color(199, 220, 79).ToVector3() * 0.8f * strength); 
            return false;
        }


        public override Color? GetAlpha(Dust dust, Color lightColor) => new Color(255, 255, 255, 25);
    }
}