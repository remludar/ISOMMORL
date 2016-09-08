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

        public void Idle(int a, int b, int c)
        {
            if (counter == 10)
            {
                if (_CurrentFrame < _TotalFrames)
                {
                    _CurrentFrame++;

                }
                else
                    _CurrentFrame = 0;
                counter = 0;
            }
            else counter++;
        }

        public void Walk(int direction)
        {
            _CurrentFrame = direction;
        }

        public void Walk(int a, int b, int c)
        {
            if (_CurrentFrame < a || _CurrentFrame > c)
                _CurrentFrame = b;
            if (counter == 10)
            {
                if (forward)
                {
                    _CurrentFrame++;
                    if (_CurrentFrame == c)
                        forward = false;
                }
                else
                {
                    _CurrentFrame--;
                    if (_CurrentFrame == a)
                        forward = true;
                }
                counter = 0;

            }
            else
                counter++;
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
    