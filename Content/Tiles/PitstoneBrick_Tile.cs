using Contagion.Content.Dusts;
using Contagion.Content.Items.TileItems;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles
{
    public class PitstoneBrick_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileBlockLight[Type] = true;
            TileID.Sets.BlockMergesWithMergeAllBlock[Type] = true;

            DustType = ModContent.DustType<PitstoneDust>();
            SoundType = SoundID.Tink;
            ItemDrop = ModContent.ItemType<PitstoneBrick>();
            AddMapEntry(new Color(0, 50, 0));
        }
    }
}
