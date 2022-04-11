using Contagion.Content.Particles;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace Contagion.Content.Tiles
{
    public class SeaGreenIce_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            TileID.Sets.Conversion.Ice[Type] = true;

            DustType = ModContent.DustType<Particles.Dusts.SeaGreenIceDust>();
            SoundType = -1;
            ItemDrop = ModContent.ItemType<SeaGreenIce>();
            AddMapEntry(new Color(143, 224, 155));
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.LocalPlayer.Center.Distance(new Vector2(i * 16, j * 16)) < 500)
                SoundEngine.PlaySound(new LegacySoundStyle(2, 50));
        }
    }
}
