using Contagion.Content.Tiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Contagion
{
    public static class ConUtils
    {
        //sort of a base
        private static void Convert(int i, int j, bool convertTile, bool convertWall, int toTileType, int toWallType, int size = 4)
        {
            for (int x = i - size; x <= i + size; x++)
            {
                for (int y = j - size; y <= j + size; y++)
                {
                    bool range = Math.Abs(x - i) + Math.Abs(y - j) < Math.Sqrt((size * size) + (size * size));
                    if (WorldGen.InWorld(x, y, 1) && range)
                    {
                        if (convertTile) 
                        {
                            Main.tile[x, y].TileType = (ushort)toTileType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (convertWall)
                        {
                            Main.tile[x, y].WallType = (ushort)toWallType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                    } 
                }
            }
        }

        public static void ContagionInfect(int i, int j, int size = 4)
        {
            int grassType = ModContent.TileType<ContagionGrass_Tile>();
            int stoneType = ModContent.TileType<Pitstone_Tile>();
            //int thornType = ModContent.TileType<Pitstone_Tile>();
            //int iceType = ModContent.TileType<Pitstone_Tile>();

            //int sandType = ModContent.TileType<Pitstone_Tile>();
            //int sandStoneType = ModContent.TileType<Pitstone_Tile>();
            //int hardSandType = ModContent.TileType<Pitstone_Tile>();

            //int grassWallType = ModContent.TileType<ContagionGrass_Tile>();
            //int stoneWallType = ModContent.TileType<Pitstone_Tile>();

            //int sandWallStoneType = ModContent.TileType<Pitstone_Tile>();
            //int hardWallSandType = ModContent.TileType<Pitstone_Tile>();

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
                        if (TileID.Sets.Conversion.Grass[tile])
                        {
                            Main.tile[x, y].TileType = (ushort)grassType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }
                        if (TileID.Sets.Conversion.Stone[tile])
                        {
                            Main.tile[x, y].TileType = (ushort)stoneType;
                            WorldGen.SquareTileFrame(x, y);
                            NetMessage.SendTileSquare(-1, x, y, 1);
                        }

                        //walls
                        //if (WallID.Sets.Conversion.Grass[wall])
                        //{
                        //    Main.tile[x, y].WallType = (ushort)grassWallType;
                        //    WorldGen.SquareTileFrame(x, y);
                        //    NetMessage.SendTileSquare(-1, x, y, 1);
                        //}                        
                        //if (WallID.Sets.Conversion.Stone[wall])
                        //{
                        //    Main.tile[x, y].WallType = (ushort)stoneWallType;
                        //    WorldGen.SquareTileFrame(x, y);
                        //    NetMessage.SendTileSquare(-1, x, y, 1);
                        //}
                    }
                }
            }
        }
    }
}
