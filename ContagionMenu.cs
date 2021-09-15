using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace Contagion
{
    public class ContagionMenu : ModMenu
    {
        public override Asset<Texture2D> Logo => Mod.Assets.Request<Texture2D>("Assets/Textures/ContagionLogo");

        //public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.Find<ModSurfaceBackgroundStyle>("Contagion/ContagionSurfaceBackgroundStyle");

        //public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/Mharadium");
    }
}
