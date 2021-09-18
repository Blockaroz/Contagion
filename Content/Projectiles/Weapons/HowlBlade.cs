using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Projectiles.Weapons
{
    public class HowlBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Howl Blade");
            ProjectileID.Sets.TrailingMode[Type] = 2;
            ProjectileID.Sets.TrailCacheLength[Type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.localNPCHitCooldown = 10;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 512;
        }

        public override void AI()
        {
            Projectile.rotation += MathHelper.ToRadians(33 * Projectile.direction);
            if (Projectile.velocity.Length() < 20)
            {
                Projectile.velocity *= 1.05f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;

        public override bool PreDraw(ref Color lightColor)
        {
            Asset<Texture2D> texture = TextureAssets.Projectile[Type];

            float spawnAlpha = Utils.GetLerpValue(512, 480, Projectile.timeLeft, true);

            for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Type]; i++)
            {
                if (i > 0)
                {
                    Color trailColor = Color.PaleGoldenrod;
                    trailColor.A /= 2;
                    float alphaLerp = Utils.GetLerpValue(4, 1, i) * 0.7f;
                    Main.EntitySpriteDraw(texture.Value, Projectile.oldPos[i] + (texture.Size() / 2) - Main.screenPosition, new Rectangle?(texture.Frame()), trailColor * alphaLerp * spawnAlpha, Projectile.oldRot[i] + MathHelper.PiOver4, texture.Size() / 2, Projectile.scale * 0.8f, SpriteEffects.None, 0);
                }
            }
            Lighting.AddLight(Projectile.position, Color.DarkGoldenrod.ToVector3());
            Color drawColor = Color.White;
            drawColor.A /= 2;
            Main.EntitySpriteDraw(texture.Value, Projectile.Center - Main.screenPosition, new Rectangle?(texture.Frame()), drawColor * spawnAlpha, Projectile.rotation + MathHelper.PiOver4, texture.Size() / 2, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < Main.rand.Next(36, 42); i++)
            {
                Vector2 dir = Projectile.velocity;
                dir.Normalize();
                dir *= 5f;
                Dust dust = Dust.NewDustDirect(Projectile.Center - new Vector2(14), 28, 28, DustID.Ichor, dir.X, dir.Y, 0, Color.White, 1f);
                dust.noGravity = true;
                dust.velocity *= 0.7f;
            }
        }
    }
}
