using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace Contagion.Content.Items.Consumable
{
	public class SeaGreenSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sea Green Solution");
			Tooltip.SetDefault("Used by the Clentaminator\nSpreads the Contagion");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
		}

		public override void SetDefaults()
		{
			Item.shoot = ModContent.ProjectileType<Projectiles.SeaGreenSolutionProjectile>() - ProjectileID.PureSpray;
			Item.ammo = AmmoID.Solution;
			Item.width = 10;
			Item.height = 12;
			Item.value = Item.buyPrice(0, 0, 25);
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
			Item.consumable = true;
		}
	}
}
