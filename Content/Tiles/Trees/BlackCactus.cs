using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles.Trees
{
    public class BlackCactus : ModCactus
    {
        private static Mod Mod { get => ModContent.GetInstance<Contagion>(); }

        public override Texture2D GetTexture() => Mod.Assets.Request<Texture2D>("Content/Tiles/Trees/BlackCactus").Value;
    }
}
