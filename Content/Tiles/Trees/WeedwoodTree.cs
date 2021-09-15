﻿using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;   

namespace Contagion.Content.Tiles.Trees
{
    public class WeedwoodTree : ModTree
    {
        private Mod Mod => ModLoader.GetMod("Contagion");

        public override int DropWood() => ItemID.Wood;

        public override Texture2D GetBranchTextures(int i, int j, int trunkOffset, ref int frame) => Mod.Assets.Request<Texture2D>("WeedwoodTree_Branches").Value;

        public override Texture2D GetTexture() => Mod.Assets.Request<Texture2D>("WeedwoodTree").Value;

        public override Texture2D GetTopTextures(int i, int j, ref int frame, ref int frameWidth, ref int frameHeight, ref int xOffsetLeft, ref int yOffset) => Mod.Assets.Request<Texture2D>("WeedwoodTree_Tops").Value;
    }
}
