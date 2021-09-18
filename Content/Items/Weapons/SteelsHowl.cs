using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Weapons
{
    public class SteelsHowl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel's Howl");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 56;
            Item.damage = 48;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(gold: 4);
            Item.rare = ItemRarityID.Orange;
            Item.scale = 1.2f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust red = Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CrimsonTorch, player.direction * 2f * (player.velocity.Length() / 10), Scale: 2f);
                    red.noGravity = true;
                }

                Dust blood = Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, player.direction * 2f * (player.velocity.Length() / 10), 0, 128, Scale: 1.4f);
                blood.noGravity = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BloodButcherer)
                .AddIngredient(ItemID.Muramasa)
                .AddIngredient(ItemID.BladeofGrass)
                .AddIngredient(ItemID.FieryGreatsword)
                .AddTile(TileID.DemonAltar)
                .Register();
                
        }
    }
}
