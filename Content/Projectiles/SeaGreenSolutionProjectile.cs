using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Contagion.Content;

namespace Contagion.Content.Projectiles
{
    public class SeaGreenSolutionProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sea Green Spray");
        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 2;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
        }

        public ref float Progress => ref Projectile.ai[0];

        public override void AI()
        {
            if (Projectile.owner == Main.myPlayer)
                ConUtils.ContagionInfect((int)Projectile.Center.X / 16, (int)Projectile.Center.Y / 16, 2);

            if (Projectile.timeLeft > 133)
                Projectile.timeLeft = 133;

            Progress++;

            if (Progress > 7f)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<Particles.SeaGreenSolution>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100);
                dust.noGravity = true;
                dust.scale *= 1.75f;
                dust.velocity *= 2f;
                dust.scale *= MathHelper.Clamp(Progress - 8f, 0f, 3f) / 3f;
            }
        }
    }
}
