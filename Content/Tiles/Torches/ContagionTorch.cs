using Contagion.Content.Tiles;
using Contagion.Core;
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
            DisplayName.SetDefault("Contagion Torch");
            ItemID.Sets.Torches[Type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.DefaultToTorch(ModContent.TileType<ContagionTorch_Tile>());
            Item.createTile = ModContent.TileType<ContagionTorch_Tile>();
            Item.placeStyle = 0;
        }

        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup)
        {
            itemGroup = ContentSamples.CreativeHelper.ItemGroup.Torches;
        }

        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
                Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, ModContent.DustType<Particles.Dusts.ContagionFlameDust>());

            Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
            Lighting.AddLight(position, new Color(154, 219, 32).ToVector3() * 0.8f);
        }

        public override void PostUpdate()
        {
            if (!Item.wet)
                Lighting.AddLight(Item.Center, new Color(154, 219, 32).ToVector3() * 0.8f);
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
