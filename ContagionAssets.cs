using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Contagion
{
    public static class ContagionAssets
    {
        private static Mod Mod { get => ModContent.GetInstance<Contagion>(); }

        public static readonly Asset<Texture2D> Bloom = Mod.Assets.Request<Texture2D>("Assets/Textures/Bloom");
    }
}
