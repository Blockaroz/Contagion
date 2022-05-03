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

        //public override void FrameEffects()
        //{
        //    if (ferrymanOn)
        //    {
        //        if (Main.rand.Next(90) < Math.Max(2, Player.velocity.Length()))
        //        {
        //            Vector2 position = Player.Center + Main.rand.NextVector2Circular(15, 10) + new Vector2(0, 18);
        //            Vector2 velocity = (-Vector2.UnitY * Main.rand.NextFloat()) + (Player.velocity * 0.1f);
        //            Particle soul = Particle.NewParticle(Particle.ParticleType<Particles.Soul>(), position, velocity, new Color(255 - Main.rand.Next(15), 255, 255, 128));
        //            soul.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(Player.cBody, Player);
        //        }
        //    }
        //}

        public override void ResetEffects()
        {
            ferrymanOn = false;
        }
    }

    public class FerrymanSouls : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.ForbiddenSetRing);

        //public override bool IsHeadLayer => true;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => drawInfo.drawPlayer.GetModPlayer<FerrymanVisuals>().ferrymanOn;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Asset<Texture2D> souls = Mod.Assets.Request<Texture2D>("Assets/Textures/Armor/FerrymanSouls");
            Vector2 drawPos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 back = new Vector2(15 * -drawInfo.drawPlayer.direction, 5 * -drawInfo.drawPlayer.gravDir);

            int frameCounter = (int)(drawInfo.drawPlayer.miscCounterNormalized * 40) % 4;
            Rectangle frame = souls.Frame(1, 4, 0, frameCounter);
            DrawData soulsData = new DrawData(souls.Value, drawPos + back, frame, Color.White, drawInfo.drawPlayer.bodyRotation, frame.Size() * 0.5f, 1f, drawInfo.playerEffect, 0);
            soulsData.shader = drawInfo.drawPlayer.cBody;
            drawInfo.DrawDataCache.Add(soulsData);
        }
    }

    public class FerrymanHoodGlow : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        public override bool IsHeadLayer => true;

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => (drawInfo.drawPlayer.armor[10].IsAir && drawInfo.drawPlayer.armor[0].ModItem is FerrymanHood) || drawInfo.drawPlayer.armor[10].ModItem is FerrymanHood;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Asset<Texture2D> glowMask = Mod.Assets.Request<Texture2D>("Assets/Textures/Armor/FerrymanHood_Glow");
            Vector2 drawPos = drawInfo.drawPlayer.GetHelmetDrawOffset() + new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.headPosition + drawInfo.headVect;
            DrawData glowMaskData = new DrawData(glowMask.Value, drawPos, drawInfo.drawPlayer.bodyFrame, Color.White, drawInfo.drawPlayer.headRotation, drawInfo.headVect, 1f, drawInfo.playerEffect, 0);
            glowMaskData.shader = drawInfo.drawPlayer.cHead;
            drawInfo.DrawDataCache.Add(glowMaskData);
        }
    }

    public class FerrymanCloakGlow : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Torso);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => (drawInfo.drawPlayer.armor[11].IsAir && drawInfo.drawPlayer.armor[1].ModItem is FerrymanCloak) || drawInfo.drawPlayer.armor[11].ModItem is FerrymanCloak;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Asset<Texture2D> glowMask = Mod.Assets.Request<Texture2D>("Assets/Textures/Armor/FerrymanCloak_Glow");
            Vector2 drawPos = new Vector2((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(drawInfo.drawPlayer.bodyFrame.Width / 2) + (float)(drawInfo.drawPlayer.width / 2)), (int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)drawInfo.drawPlayer.height - (float)drawInfo.drawPlayer.bodyFrame.Height + 4f)) + drawInfo.drawPlayer.bodyPosition + new Vector2(drawInfo.drawPlayer.bodyFrame.Width / 2, drawInfo.drawPlayer.bodyFrame.Height / 2);
            Vector2 value = Main.OffsetsPlayerHeadgear[drawInfo.drawPlayer.bodyFrame.Y / drawInfo.drawPlayer.bodyFrame.Height];
            value.Y -= 2f;
            drawPos += value * -drawInfo.playerEffect.HasFlag(SpriteEffects.FlipVertically).ToDirectionInt();
            drawPos.Y += drawInfo.torsoOffset;
            DrawData glowMaskData = new DrawData(glowMask.Value, drawPos, drawInfo.compTorsoFrame, Color.White, drawInfo.drawPlayer.bodyRotation, drawInfo.bodyVect, 1f, drawInfo.playerEffect, 0);
            glowMaskData.shader = drawInfo.drawPlayer.cBody;
            drawInfo.DrawDataCache.Add(glowMaskData);
        }
    }
}
