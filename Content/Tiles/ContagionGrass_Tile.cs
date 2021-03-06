using Contagion.Content.Particles;
using Contagion.Content.Tiles.Foliage;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Contagion.Content.Tiles
{
    public class ContagionGrass_Tile : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.Conversion.Grass[Type] = true;
            TileID.Sets.Conversion.MergesWithDirtInASpecialWay[Type] = true;
            TileID.Sets.Grass[Type] = true;
            TileID.Sets.NeedsGrassFraming[Type] = true;
            TileID.Sets.NeedsGrassFramingDirt[Type] = TileID.Dirt;
            TileID.Sets.AvoidedByNPCs[Type] = true;
            Main.tileBrick[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[Type][TileID.Dirt] = true;

            DustType = ModContent.DustType<Particles.Dusts.ContagionFoliage1>();
            ItemDrop = ItemID.DirtBlock;
            AddMapEntry(new Color(109, 127, 52));
        }

        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
        {
            TileObject toBePlaced;
            if (!TileObject.CanPlace(x, y, type, style, direction, out toBePlaced, false))
                return false;

            toBePlaced.random = random;
            if (TileObject.Place(toBePlaced) && !mute)
                WorldGen.SquareTileFrame(x, y, true);

            return false;
        }
        
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail)
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = TileID.Dirt;
            }
        }
    }
}
