using System;
using Contagion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;

namespace Contagion.Content.Particles
{
    public class Soul : Particle
    {
        public override void OnSpawn()
        {
            scale *= Main.rand.NextFloat(0.9f, 1.8f);
            rotation *= 0.1f;
            frame = 0;
            frameCounter = 0;
        }

        private int frame;
        private int frameCounter;

        public override void Update()
        {
            //ember ai
            velocity *= 0.98f;
            if (Main.rand.Next(4) == 0)
                velocity += Main.rand.NextVector2Circular(0.3f, 0.2f);
            velocity.Y -= 0.033f;

            rotation = velocity.ToRotation() + MathHelper.PiOver2;

            //frames
            frameCounter++;
            if (frameCounter > 10)
            {
                frame++;
                frameCounter = 0;
            }
            if (frame >= 4)
                Active = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Asset<Texture2D> soul = Mod.Assets.Request<Texture2D>("Content/Particles/Soul");
            Asset<Texture2D> bloom = Mod.Assets.Request<Texture2D>("Assets/Textures/Bloom");
            Rectangle rect = soul.Frame(1, 4, 0, frame);
            Color bloomColor = color * 0.9f;
            bloomColor.A = 0;
            spriteBatch.Draw(soul.Value, position - Main.screenPosition, rect, color, rotation, rect.Size() * new Vector2(0.5f, 0.33f), scale, SpriteEffects.None, 0);
            spriteBatch.Draw(bloom.Value, position - Main.screenPosition, null, bloomColor, rotation, bloom.Size() * 0.5f, scale * 0.5f, SpriteEffects.None, 0);
        }
    }
}
