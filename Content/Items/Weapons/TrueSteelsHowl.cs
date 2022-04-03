using Contagion.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Weapons
{
    public class TrueSteelsHowl : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Steel's Howl");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 58;
            Item.damage = 100;
            Item.useTime = 40;
            Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.buyPrice(gold: 4);
            Item.rare = ItemRarityID.Yellow;
            Item.scale = 1.2f;
            Item.shoot = ModContent.ProjectileType<HowlBlade>();
            Item.shootSpeed = 5;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            SoundEngine.PlaySound(SoundID.Item114, position);
            damage = 125;
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Dust spark = Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Ichor, 0, 0, 0, Color.White, 1f);
                    spark.noGravity = true;
                    spark.velocity.X = player.direction * 2f * (player.velocity.Length() / 10);
                }

                if (Main.rand.Next(4) == 0)
                {
                    Dust red = Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CrimsonTorch, player.direction * 2f * (player.velocity.Length() / 10), Scale: 2f);
                    red.noGravity = true;
                }

                Dust blood = Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, 0, 0, 128, Scale: 1.4f);
                blood.noGravity = true;
                blood.velocity.X = player.direction * 2f * (player.velocity.Length() / 10);
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SteelsHowl>())
                .AddIngredient(ItemID.SoulofFright, 20)
                .AddIngredient(ItemID.SoulofSight, 20)
                .AddIngredient(ItemID.SoulofMight, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            //terra blade
            Recipe terraBlade = CreateRecipe()
                .AddIngredient(ModContent.ItemType<TrueSteelsHowl>())
                .AddIngredient(ItemID.TrueExcalibur)
                .AddIngredient(ItemID.BrokenHeroSword)
                .AddTile(TileID.MythrilAnvil);
            terraBlade.ReplaceResult(ItemID.TerraBlade);
            terraBlade.Register();

        }
    }
}
