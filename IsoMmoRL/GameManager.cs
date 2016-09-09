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

        private Camera camera;
        private Terrain terrain;
        private Player player;
        public static SpriteFont myFont { get; set; }
        //private Map map;

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

            player = new Player();

            camera = new Camera();
            camera.ViewportWidth = graphics.GraphicsDevice.Viewport.Width;
            camera.ViewportHeight = graphics.GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            terrain = new Terrain(graphics, Content.Load<Texture2D>("Images/isoPrototypeTiles"));
            player.Init(graphics, Content.Load<Texture2D>("Images/PlayerSheet"));
            myFont = Content.Load<SpriteFont>("MyFont");
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
            player.Update();
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

            terrain.Draw(spriteBatch);

            spriteBatch.DrawString(myFont, Player.GetPosition().ToString(), new Vector2(Player.GetPosition().X, Player.GetPosition().Y + 100), Color.White, 0.0f, new Vector2(100, 100), 1.0f, SpriteEffects.None, 0);

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
