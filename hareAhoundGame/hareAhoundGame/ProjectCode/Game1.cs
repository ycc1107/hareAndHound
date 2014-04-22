using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using hareAhoundGame.ProjectCode;


namespace hareAhoundGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : InitImage
    {

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            base.init();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            base.beginStage();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            MoveObj move = new MoveObj();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);

            spriteBatch.Draw(hare, harePosition, null, Color.White, 0, Vector2.Zero,1,SpriteEffects.None,1);
            spriteBatch.Draw(hound1, hound1Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(hound2, hound2Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(hound3, hound3Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(background, backgroundPosition, null, Color.BlanchedAlmond, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
