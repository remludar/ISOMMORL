using Microsoft.Xna.Framework;
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
            tileSizeWidth = 128;
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
            switch (tileNum)
            {
                case 0:
                    return tiles[new Vector2(1, 0)];
                case 1:
                    return tiles[new Vector2(2, 0)];
                case 2:
                    return tiles[new Vector2(1, 1)];
                case 3:
                    return tiles[new Vector2(2, 1)];
                case 4:
                    return tiles[new Vector2(4, 0)];
                case 5:
                    return tiles[new Vector2(5, 0)];
                case 6:
                    return tiles[new Vector2(6, 0)];                
                case 7:
                    return tiles[new Vector2(7, 0)];
                case 8:
                    return tiles[new Vector2(0, 1)];
                case 9:
                    return tiles[new Vector2(3, 1)];
                case 10:
                    return tiles[new Vector2(6, 1)];
                case 11:
                    return tiles[new Vector2(4, 1)];
                case 12:
                    return tiles[new Vector2(7, 1)];
                case 13:
                    return tiles[new Vector2(5, 1)];
                default:
                    return tiles[new Vector2(0, 0)];
            }
        }
    }
}
