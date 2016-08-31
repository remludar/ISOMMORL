using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace IsoMmoRL
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameManager : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D tileSheet;

        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            var width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - graphics.PreferredBackBufferWidth / 2;
            var height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - graphics.PreferredBackBufferHeight / 2;
            this.Window.Position = new Point(width, height);
            
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //tileSheet = Content.Load<Texture2D>("Images/isoPrototypeTiles");
            tileSheet = Content.Load<Texture2D>("Images/MyIsoTiles");
            TileManager.Init(tileSheet);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();

            int textureWidth = 64;
            int textureHeight = 64;
            int mapWidth = 15;
            int mapHeight = 15;
            int startingPosX = (graphics.PreferredBackBufferWidth / textureWidth / 2) * textureWidth - (textureWidth / 2);
            int startingPosY = (graphics.PreferredBackBufferHeight / textureHeight / 2) * textureHeight - (mapHeight * textureWidth / 4) - (textureHeight / 2);


            //Draw a basic flat grass level
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    var texture = TileManager.tiles[new Vector2(0, 2)];
                    var sourceRectangle = texture.Bounds;
                    int posX = x * (textureWidth / 2) - y * (textureHeight / 2);
                    int posY = y * (textureHeight / 4) + x * (textureWidth / 4);
                    spriteBatch.Draw(texture.Texture, new Rectangle(startingPosX + posX, startingPosY + posY, TileManager.tileSizeWidth, TileManager.tileSizeHeight), sourceRectangle, Color.White);
                }
            }




            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
