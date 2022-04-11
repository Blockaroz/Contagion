using Contagion.Content.Particles;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles
{
    public class MiaxumOre_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 330;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1150;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            DustType = ModContent.DustType<Particles.Dusts.MiaxumDust>();
            SoundType = SoundID.Tink;
            ItemDrop = ModContent.ItemType<Items.MiaxumOre>();
            AddMapEntry(new Color(55, 198, 79));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.2f;
            b = 0.13f;
        }
    }
}
