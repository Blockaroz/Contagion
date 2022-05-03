using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FerrymanHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ferryman's Hood");
            Tooltip.SetDefault("'From the earth, he draws strength...'");
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

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<FerrymanCloak>() && legs.type == ModContent.ItemType<FerrymanRobe>();

        public override void EquipFrameEffects(Player player, EquipType type) => player.GetModPlayer<FerrymanVisuals>().ferrymanOn = true;

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Vertebrae, 10)
                .AddIngredient(ItemID.Bone, 10)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
