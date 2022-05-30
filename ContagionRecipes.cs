using Contagion.Content.Items;
using Contagion.Content.Items.TileItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
    public static class ContagionRecipes
    {
        private static Mod Mod => ModContent.GetInstance<Contagion>();  
        
        private static void OreRecipes()
        {
            //Magiluminescence
            Mod.CreateRecipe(ItemID.Magiluminescence)
                .AddIngredient(ItemID.Topaz, 5)
                .AddIngredient<MiaxumBar>(12)
                .AddTile(TileID.Anvils)
                .Register();

            //Deer Thing
            Mod.CreateRecipe(ItemID.DeerThing)
                .AddIngredient(ItemID.FlinxFur, 3)
                .AddIngredient(ItemID.Lens)
                .AddIngredient<MiaxumOre>(5)
                .AddTile(TileID.DemonAltar)
                .Register();
        }

        private static void OrganicsRecipes()
        {
            //Coffin Minecart
            Mod.CreateRecipe(ItemID.CoffinMinecart)
                .AddIngredient(RecipeGroupID.IronBar, 5)
                .AddIngredient(RecipeGroupID.Wood, 10)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Anvils)
                .AddCondition(Recipe.Condition.InGraveyardBiome);

            //Mechanical Worm
            Mod.CreateRecipe(ItemID.MechanicalWorm)
                .AddIngredient(ItemID.Vertebrae)
                .AddIngredient(RecipeGroupID.IronBar, 5)
                .AddIngredient(ItemID.SoulofNight, 6)
                .AddTile(TileID.MythrilAnvil);

            //Battle Potion
            Mod.CreateRecipe(ItemID.BattlePotion)
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Deathweed)
                .AddIngredient(ItemID.Vertebrae)
                .AddTile(TileID.Bottles);

            //Obsidian Armor set
            Mod.CreateRecipe(ItemID.ObsidianHelm)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 10)
                .AddTile(TileID.Hellforge);

            Mod.CreateRecipe(ItemID.ObsidianShirt)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 5)
                .AddTile(TileID.Hellforge);

            Mod.CreateRecipe(ItemID.ObsidianPants)
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.Obsidian, 20)
                .AddIngredient(ItemID.TissueSample, 5)
                .AddTile(TileID.Hellforge);

            //Void Bag
            Mod.CreateRecipe(ItemID.VoidLens)
                .AddIngredient(ItemID.Bone, 30)
                .AddIngredient(ItemID.JungleSpores, 15)
                .AddIngredient(ItemID.TissueSample, 30)
                .AddTile(TileID.DemonAltar);

            //Void Vault
            Mod.CreateRecipe(ItemID.VoidVault)
                .AddIngredient(ItemID.Bone, 15)
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddIngredient(ItemID.TissueSample, 15)
                .AddTile(TileID.DemonAltar);
        }

        public static void AddRecipes()
        {
            //Disable Recipe for Night's Edge's in crimson
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.HasIngredient(ItemID.BloodButcherer) &&
                recipe.HasIngredient(ItemID.Muramasa) &&
                recipe.HasIngredient(ItemID.BladeofGrass) &&
                recipe.HasIngredient(ItemID.FieryGreatsword) &&
                recipe.HasResult(ItemID.NightsEdge))
                    recipe.DisableRecipe();
            }

            OrganicsRecipes();
            OreRecipes();

            //Desert Torch
            Mod.CreateRecipe(ItemID.DesertTorch, 3)
                .AddIngredient(ItemID.Torch, 3)
                .AddIngredient<HardenedPitsand>()
                .Register();
        }
    }
}
