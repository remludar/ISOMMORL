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

        public static void Init(Texture2D tileSheet)
        {
            int tileSize = 64;
            int width = tileSheet.Width / tileSize;
            int height = 1;// tileSheet.Height / tileSize;
            

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var textureRegion = new TextureRegion2D("test", tileSheet, x * tileSize, y * tileSize, tileSize, tileSize);

                    tiles.Add(new Vector2(x, y), textureRegion);
                }
            }

        }
    }
}
