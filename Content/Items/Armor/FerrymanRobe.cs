using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FerrymanRobe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ferryman's Robe");
            Tooltip.SetDefault("'Our strength...'");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.vanity = true;
            Item.value = Item.buyPrice(0, 0, 50);
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => head.type == ModContent.ItemType<FerrymanHood>() && body.type == ModContent.ItemType<FerrymanCloak>();

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Silk, 20)
                .AddIngredient(ItemID.Vertebrae, 10)
                .AddIngredient(ItemID.BlackDye)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
