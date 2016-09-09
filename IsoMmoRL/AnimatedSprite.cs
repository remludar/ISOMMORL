using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoMmoRL
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        private int _CurrentFrame;
        private int _TotalFrames;
        private int counter;
        private bool forward;

        public AnimatedSprite(Texture2D texture, int columns, int rows)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            _CurrentFrame = 0;
            _TotalFrames = rows * columns;
            counter = 0;
            forward = true;
        }

        public void Update()
        {

        }

        public void Walk(int direction)
        {
            _CurrentFrame = direction;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)_CurrentFrame / (float)Columns);
            int column = _CurrentFrame % Columns;

            var sourceRectangle = new Rectangle(width * column, height * row, width, height);
            var destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
    