using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
	public class Contagion : Mod
    {
        public override void Load()
        {
            ParticleEngine.ParticleLoader.Load();
        }

        public override void Unload()
        {
            ParticleEngine.ParticleLoader.Unload();
        }

        public override void AddRecipes()
        {
            ContagionRecipes.AddRecipes();
        }
    }
}