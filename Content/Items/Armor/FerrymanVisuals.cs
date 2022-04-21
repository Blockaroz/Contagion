using Contagion.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Armor
{
    public class FerrymanVisuals : ModPlayer
    {
        public bool ferrymanOn;

        public override void PostUpdateMiscEffects()
        {
            if (Main.rand.Next(50) < Math.Max(2, Player.velocity.Length()))
            {
                Vector2 position = Player.Center + Main.rand.NextVector2Circular(15, 18);
                Vector2 velocity = (-Vector2.UnitY * Main.rand.NextFloat()) + (Player.velocity * 0.3f);
                Particle.NewParticle(Particle.ParticleType<Particles.Soul>(), position, velocity, new Color(255 - Main.rand.Next(15), 255, 255, 0));
            }
        }

        public override void ResetEffects()
        {
            ferrymanOn = false;
        }
    }

    public class FerrymanHoodGlow : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        public override bool IsHeadLayer => true;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            bool notVanity = drawInfo.drawPlayer.armor[10].IsAir && drawInfo.drawPlayer.armor[0].ModItem is FerrymanHood;
            bool vanity = drawInfo.drawPlayer.armor[10].ModItem is FerrymanHood;
            if (vanity || notVanity)
                DrawMask(drawInfo);
        }

        private void DrawMask(PlayerDrawSet drawInfo)
        {
            Asset<Texture2D> glowMask = Mod.Assets.Request<Texture2D>("Assets/Textures/Armor/FerrymanHood_Glow");
            Vector2 drawPos = drawInfo.drawPlayer.GetHelmetDrawOffset() + new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.headPosition + drawInfo.headVect;
            DrawData glowMaskData = new DrawData(glowMask.Value, drawPos, drawInfo.drawPlayer.bodyFrame, new Color(255, 255, 255, 50), drawInfo.drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
            drawInfo.DrawDataCache.Add(glowMaskData);
        }
    }
    public class FerrymanCloakGlow : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Torso);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            bool notVanity = drawInfo.drawPlayer.armor[11].IsAir && drawInfo.drawPlayer.armor[1].ModItem is FerrymanCloak;
            bool vanity = drawInfo.drawPlayer.armor[11].ModItem is FerrymanCloak;
            if (vanity || notVanity)
                DrawMask(drawInfo);
        }

        private void DrawMask(PlayerDrawSet drawInfo)
        {
            Asset<Texture2D> glowMask = Mod.Assets.Request<Texture2D>("Assets/Textures/Armor/FerrymanCloak_Glow");
            Vector2 drawPos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            drawPos += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            drawPos.Y += drawInfo.torsoOffset;
            DrawData glowMaskData = new DrawData(glowMask.Value, drawPos, drawInfo.compTorsoFrame, new Color(255, 255, 255, 50), drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
            drawInfo.DrawDataCache.Add(glowMaskData);
        }
    }
}
