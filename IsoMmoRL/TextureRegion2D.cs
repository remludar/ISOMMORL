using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoMmoRL
{
    public class TextureRegion2D
    {
        public TextureRegion2D(int level, Texture2D texture, int x, int y, int width, int height)
        {
            if (texture == null) throw new ArgumentNullException("texture");

            Level = level;
            Texture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Level { get; private set; }
        public Texture2D Texture { get; protected set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle Bounds
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }
    }
}
