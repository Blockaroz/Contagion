using Terraria;
using Terraria.ModLoader;

namespace Contagion.Content.Biomes.Backgrounds
{
	public class ContagionSurfaceBackground : ModSurfaceBackgroundStyle
	{
		public override void ModifyFarFades(float[] fades, float transitionSpeed)
		{
			for (int i = 0; i < fades.Length + 1; i++)
			{
				if (i == Slot)
				{
					fades[i] += transitionSpeed;
					if (fades[i] > 1f)
					{
						fades[i] = 1f;
					}
				}
				else
				{
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f)
					{
						fades[i] = 0f;
					}
				}
			}
		}

		public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) => BackgroundTextureLoader.GetBackgroundSlot("Contagion/Content/Biomes/Backgrounds/ContagionSurfaceFront");
		public override int ChooseMiddleTexture() => BackgroundTextureLoader.GetBackgroundSlot("Contagion/Content/Biomes/Backgrounds/ContagionSurfaceMid");
		public override int ChooseFarTexture() => BackgroundTextureLoader.GetBackgroundSlot("Contagion/Content/Biomes/Backgrounds/ContagionSurfaceBack");
	}
}
