using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Vigil
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputHandler inputHandler = new InputHandler();

        public struct ShipMovements
        {
            public Vector2 VelocityChange;
            public float SpinChange;
        }

        public Game1()
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
            // TODO: Add your initialization logic here
            var playerShip = ShipManager.Instance.SpawnShip(ShipType.Corvette);
            ShipManager.Instance.SetPlayerShip(playerShip);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load all shiptype textures
            ShipTextureManager.Instance.Load(this);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Parse current keyboard state and update player speed
            ShipMovements shipMove = inputHandler.Parse(out bool exit);
            if (exit)
                Exit();

            ShipManager.Instance.GetPlayerShip().UpdateMoves(shipMove);
            ShipManager.Instance.UpdatePositions();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.TransparentBlack);

            spriteBatch.Begin();
            foreach (var shipPos in ShipManager.Instance.GetShipPositions())
            {
                Texture2D texture = ShipTextureManager.Instance.GetTexture(shipPos.Key.GetShipType());
                Vector2 location = shipPos.Value;
                Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                float angle = shipPos.Key.GetAngle();
                Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

                spriteBatch.Draw(texture, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
