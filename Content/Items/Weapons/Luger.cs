using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Weapons
{
	public class Luger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Luger");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() 
		{
			Item.damage = 18;
			Item.knockBack = 1;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.DamageType = DamageClass.Ranged;
			Item.shoot = ProjectileID.Bullet;
			Item.shootSpeed = 36f;
			Item.useAmmo = AmmoID.Bullet; ;
			Item.width = 44;
			Item.height = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item40;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 1, 50, 0);
		}

		public override Vector2? HoldoutOffset() => new Vector2(-1, 0);

        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}