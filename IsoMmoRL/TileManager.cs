﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoMmoRL
{
    public static class TileManager
    {
        public static Dictionary<Vector2, TextureRegion2D> tiles = new Dictionary<Vector2, TextureRegion2D>();
        public static int tileSizeWidth, tileSizeHeight;
        public static int width, height;

        public static void Init(Texture2D tileSheet)
        {
            tileSizeWidth = 64;
            tileSizeHeight = 128;
            width = tileSheet.Width / tileSizeWidth;
            height = tileSheet.Height / tileSizeHeight;


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var textureRegion = new TextureRegion2D("test", tileSheet, x * tileSizeWidth, y * tileSizeHeight, tileSizeWidth, tileSizeHeight);

                    tiles.Add(new Vector2(x, y), textureRegion);
                }
            }
        }

        public static TextureRegion2D GetTile(int tileNum)
        {
            if (tileNum == 0)
            {
                return tiles[new Vector2(5, 0)];
            }
            if(tileNum == 1)
            {
                return tiles[new Vector2(0, 0)];
            }
            return tiles[new Vector2(6, 0)];
        }
    }
}
