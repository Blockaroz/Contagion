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
            scale *= Main.rand.NextFloat(0.5f, 1.2f);
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
            if (frameCounter > 8)
            {
                frame++;
                frameCounter = 0;
            }
            if (frame >= 4)
                Active = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Asset<Texture2D> explosion = Mod.Assets.Request<Texture2D>("Content/Particles/Soul");
            Rectangle rect = explosion.Frame(1, 4, 0, frame);
            spriteBatch.Draw(explosion.Value, position - Main.screenPosition, rect, color, rotation, rect.Size() * 0.5f, scale, SpriteEffects.None, 0);
        }
    }
}
