using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using System.IO;

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
        private Camera camera;
        private Map map;

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

            camera = new Camera();
            camera.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            camera.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;

            map = new Map(@"C:\Users\jewton\Dropbox\Personal\GameDev\MonoGame\Projects\Isometric MMO with Roguelike Quests\IsoMmoRL\IsoMmoRL\Map.txt");

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileSheet = Content.Load<Texture2D>("Images/BetterTiles");
            TileManager.Init(tileSheet);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _processInput();
            camera.Update();


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.TranslationMatrix);

            int textureWidth = 64;
            int textureHeight = 64;
            int mapWidth = map.width;
            int mapHeight = map.length;
            int startingPosX = (graphics.PreferredBackBufferWidth / textureWidth / 2) * textureWidth - (textureWidth / 2);
            int startingPosY = (graphics.PreferredBackBufferHeight / textureHeight / 2) * textureHeight - (mapHeight * textureWidth / 4) - (textureHeight / 2);


            //Draw a basic flat grass level
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    var texture = TileManager.GetTile(map.map[x,y]);
                    var sourceRectangle = texture.Bounds;
                    int posX = x * (textureWidth / 2) - y * (textureHeight / 2);
                    int posY = y * (textureHeight / 4) + x * (textureWidth / 4);
                    //int posX = x * (textureWidth / 2) + y * (textureHeight / 2);
                    //int posY = y * (textureHeight / 4) - x * (textureWidth / 4);
                    spriteBatch.Draw(texture.Texture, new Rectangle(startingPosX + posX, startingPosY + posY, TileManager.tileSizeWidth, TileManager.tileSizeHeight), sourceRectangle, Color.White);
                }
            }




            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void _processInput()
        {
            InputState.Update();
            if (InputState.Escape || InputState.Back)
            {
                Exit();
            }
        }
    }
}
