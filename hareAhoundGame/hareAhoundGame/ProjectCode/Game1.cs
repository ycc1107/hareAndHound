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
    public class Game1 : InitImage
    {
        private bool selectStatus = true;

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
       
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            base.beginStage();

        }
      
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            
            mousePosiiton = new Point(mouseState.X, mouseState.Y);

          

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);

            if (selectStatus)
            {
                spriteBatch.Draw(hare, harePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                spriteBatch.Draw(hound1, hound1Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                spriteBatch.Draw(hound2, hound2Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                spriteBatch.Draw(hound3, hound3Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }


            spriteBatch.Draw(background, backgroundPosition, null, Color.BlanchedAlmond, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
