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
            //Remove Night's Edge's crimson recipe
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasIngredient(ItemID.BloodButcherer) &&
                recipe.HasIngredient(ItemID.Muramasa) &&
                recipe.HasIngredient(ItemID.BladeofGrass) &&
                recipe.HasIngredient(ItemID.FieryGreatsword) &&
                recipe.HasResult(ItemID.NightsEdge))
                {
                    recipe.RemoveRecipe();
                }
            }
        }
    }
}