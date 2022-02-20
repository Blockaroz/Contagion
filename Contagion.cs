using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
	public class Contagion : Mod
	{
        public override void Load()
        {
            
        }

        public override void AddRecipes()
        {
            //Remove Recipe for Night's Edge's in crimson
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasIngredient(ItemID.BloodButcherer) &&
                recipe.HasIngredient(ItemID.Muramasa) &&
                recipe.HasIngredient(ItemID.BladeofGrass) &&
                recipe.HasIngredient(ItemID.FieryGreatsword) &&
                recipe.HasResult(ItemID.NightsEdge))
                    recipe.RemoveRecipe();
            }

            //Add Recipe for Magiluminescence
            CreateRecipe(ItemID.Magiluminescence)
                .AddIngredient(ItemID.Topaz, 5)
                .AddIngredient(ItemID.CrimtaneBar, 12)
                .AddTile(TileID.Anvils);

            //Add Recipe for Coffin Minecart
            CreateRecipe(ItemID.CoffinMinecart)
                .AddIngredient(RecipeGroupID.IronBar, 5)
                .AddIngredient(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome);

            //Add Recipe for Mechanical Worm
            CreateRecipe(ItemID.MechanicalWorm)
                .AddIngredient(ItemID.Vertebrae)
                .AddIngredient(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.SoulofNight, 6)
                .AddTile(TileID.MythrilAnvil);

            //Add Recipe for Battle Potion
            CreateRecipe(ItemID.BattlePotion)
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Deathweed)
                .AddIngredient(ItemID.Vertebrae)
                .AddTile(TileID.Bottles);

            //Add Recipes for Obsidian set
            CreateRecipe(ItemID.ObsidianHelm)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Hellforge);

            CreateRecipe(ItemID.ObsidianShirt)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 5)
                .AddTile(TileID.Hellforge);

            CreateRecipe(ItemID.ObsidianPants)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 5)
                .AddTile(TileID.Hellforge);

            //Add Recipes for Void Bag and Void Vault
            CreateRecipe(ItemID.VoidLens)
                .AddIngredient(ItemID.Bone, 30)
                .AddIngredient(ItemID.JungleSpores, 15)
                .AddIngredient(ItemID.TissueSample, 30)
                .AddTile(TileID.DemonAltar);

            CreateRecipe(ItemID.VoidVault)
                .AddIngredient(ItemID.Bone, 15)
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddIngredient(ItemID.TissueSample, 15)
                .AddTile(TileID.DemonAltar);
        }
    }
}