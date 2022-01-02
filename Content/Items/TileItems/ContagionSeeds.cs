using Contagion.Content.Tiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Contagion.Content.Items.TileItems
{
    public class ContagionSeeds : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Contagion Seeds");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<ContagionGrass_Tile>(), 0);
        }

        //public override bool? UseItem(Player player)
        //{
        //    if (Main.netMode == NetmodeID.Server)
        //        return false;

        //    Tile tile = Framing.GetTileSafely(Player.tileTargetX, Player.tileTargetY);

        //    Vector2 tileTarget = new Vector2(Player.tileTargetX, Player.tileTargetY);
        //    player.LimitPointToPlayerReachableArea(ref tileTarget);

        //    if (tile.IsActive && tile.type == TileID.Dirt)
        //    {
        //        WorldGen.PlaceTile((int)tileTarget.X, (int)tileTarget.Y, ModContent.TileType<ContagionGrass_Tile>(), forced: true);
        //        player.inventory[player.selectedItem].stack--;
        //    }

        //    return true;
        //}
    }
}
