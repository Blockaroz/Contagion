using Contagion.Content.Dust;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles
{
    public class Pitstone_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.Conversion.Stone[Type] = true;
            TileID.Sets.BlockMergesWithMergeAllBlock[Type] = true;

            DustType = ModContent.DustType<PitstoneDust>();
            SoundType = SoundID.Tink;
            ItemDrop = ModContent.ItemType<Pitstone>();
            AddMapEntry(new Color(24, 30, 20));
        }
    }
}
