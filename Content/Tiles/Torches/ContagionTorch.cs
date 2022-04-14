using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Tiles.Torches
{
    public class ContagionTorch : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.flame = true;
            Item.noWet = true;
            Item.holdStyle = 1;
            Item.autoReuse = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<ContagionTorch_Tile>();
            Item.width = 10;
            Item.height = 12;
            Item.value = 60;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches;
        }

        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
                Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.CursedTorch);

            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);

            Lighting.AddLight(position, new Color(199, 220, 79).ToVector3());
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
                Lighting.AddLight(Item.Center, new Color(199, 220, 79).ToVector3());
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            dryTorch = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
                .AddIngredient(ItemID.Torch, 3)
                .AddIngredient<Items.TileItems.Pitstone>()
                .Register();            
            CreateRecipe(3)
                .AddIngredient(ItemID.Torch, 3)
                .AddIngredient<Items.TileItems.SeaGreenIce>()
                .Register();            
            CreateRecipe(3)
                .AddIngredient(ItemID.Torch, 3)
                .AddIngredient<Items.TileItems.HardenedPitsand>()
                .Register();
        }
    }
}
