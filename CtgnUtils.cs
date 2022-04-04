using Contagion.Content.Tiles;
using Contagion.Content.Walls;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
    public static class CtgnUtils
    {
        //private static Mod Mod { get => ModContent.GetInstance<Contagion>(); }

        public static void InfectWithContagion(int i, int j, int size = 4)
        {
            int grassType = ModContent.TileType<ContagionGrass_Tile>();
            int stoneType = ModContent.TileType<Pitstone_Tile>();
            //int thornType = ModContent.TileType<Pitstone_Tile>();
            int iceType = ModContent.TileType<SeaGreenIce_Tile>();

            int sandType = ModContent.TileType<Pitsand_Tile>();
            int sandStoneType = ModContent.TileType<Pitsandstone_Tile>();
            int hardSandType = ModContent.TileType<HardenedPitsand_Tile>();

            //int grassWallType = ModContent.TileType<ContagionGrass_Tile>();
            int stoneWallType = ModContent.WallType<PitstoneWall_Wall>();

            int sandStoneWallType = ModContent.WallType<PitsandstoneWall_Wall>();
            int hardSandWallType = ModContent.WallType<HardenedPitsandWall_Wall>();

            for (int x = i - size; x <= i + size; x++)
            {
                for (int y = j - size; y <= j + size; y++)
                {
                    bool range = Math.Abs(x - i) + Math.Abs(y - j) < Math.Sqrt((size * size) + (size * size));
                    if (WorldGen.InWorld(x, y, 1) && range)
                    {
                        int tile = Main.tile[x, y].TileType;
                        int wall = Main.tile[x, y].WallType;

                        //tiles
                        if (TileID.Sets.Conversion.Grass[tile] && Main.tile[x, y].TileType != (ushort)grassType)
                        {
                            Main.tile[x, y].TileType = (ushort)grassType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.Stone[tile] && Main.tile[x, y].TileType != (ushort)stoneType)
                        {
                            Main.tile[x, y].TileType = (ushort)stoneType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.Ice[tile] && Main.tile[x, y].TileType != (ushort)iceType)
                        {
                            Main.tile[x, y].TileType = (ushort)iceType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.Sand[tile] && Main.tile[x, y].TileType != (ushort)sandType)
                        {
                            Main.tile[x, y].TileType = (ushort)sandType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.Sandstone[tile] && Main.tile[x, y].TileType != (ushort)sandStoneType)
                        {
                            Main.tile[x, y].TileType = (ushort)sandStoneType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.HardenedSand[tile] && Main.tile[x, y].TileType != (ushort)hardSandType)
                        {
                            Main.tile[x, y].TileType = (ushort)hardSandType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        //walls
                        //if (WallID.Sets.Conversion.Grass[wall] && Main.tile[x, y].WallType != (ushort)grassWallType)
                        //{
                        //    Main.tile[x, y].WallType = (ushort)grassWallType;
                        //    WorldGen.SquareTileFrame(x, y);
                        //    NetMessage.SendTileSquare(-1, x, y, 1);
                        //}
                        if (WallID.Sets.Conversion.Stone[wall] && Main.tile[x, y].WallType != (ushort)stoneWallType)
                        {
                            Main.tile[x, y].WallType = (ushort)stoneWallType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (WallID.Sets.Conversion.Sandstone[wall] && Main.tile[x, y].WallType != (ushort)sandStoneWallType)
                        {
                            Main.tile[x, y].WallType = (ushort)sandStoneWallType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }                        
                        if (WallID.Sets.Conversion.HardenedSand[wall] && Main.tile[x, y].WallType != (ushort)hardSandWallType)
                        {
                            Main.tile[x, y].WallType = (ushort)hardSandWallType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    }
                }
            }
        }
    }
}
