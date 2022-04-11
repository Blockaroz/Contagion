using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
	public class Contagion : Mod
	{

        public override void AddRecipes()
        {
            ContagionRecipes.AddRecipes();
        }
    }
}