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

namespace hareNhounds
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        protected Texture2D background;

        protected Vector2 backgroundPosition;
        protected Vector2 userSelectionHarePosition;
        protected Vector2 userSelectionHoundPosition;
        protected Vector2 clickArea;

        protected Rectangle userSelectionHarePositionArea;
        protected Rectangle userSelectionHoundPositionArea;

        BoardPosition BoardPosition = new BoardPosition();

        Point mousePosition;

        Animal hare;
        Animal houndOne;
        Animal houndTwo;
        Animal houndThree;


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

           
            
            this.IsMouseVisible = true;
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

            hare = new Animal();
            houndOne = new Animal();
            houndTwo = new Animal();
            houndThree = new Animal();

            background = Content.Load<Texture2D>("image/Hare_and_Hounds_board");
            backgroundPosition = BoardPosition.BOARD;

            userSelectionHarePosition = BoardPosition.HARE_SELECT;
            userSelectionHoundPosition = BoardPosition.HOUND_SELECT;

            userSelectionHarePositionArea = new Rectangle((int)userSelectionHarePosition.X,(int)userSelectionHarePosition.Y,50,50);
            userSelectionHoundPositionArea = new Rectangle((int)userSelectionHoundPosition.X, (int)userSelectionHoundPosition.Y,50,50);

            hare.setImage = Content.Load<Texture2D>("image/hare");
            hare.Position = BoardPosition.RIGHT_END;
            hare.Area = new Rectangle((int)hare.Position.X,(int)hare.Position.Y, 50, 50);

            houndOne.setImage = Content.Load<Texture2D>("image/hound");
            houndOne.Position = BoardPosition.FIRST_COLUMN_UP;
            houndOne.Area = new Rectangle((int)houndOne.Position.X, (int)houndOne.Position.Y, 50, 50);

            houndTwo.Position = BoardPosition.LEFT_END;
            houndTwo.Area = new Rectangle((int)houndTwo.Position.X, (int)houndTwo.Position.Y, 50, 50);

            houndThree.Position = BoardPosition.FIRST_COLUMN_DOWN;
            houndThree.Area = new Rectangle((int)houndThree.Position.X, (int)houndThree.Position.Y, 50, 50);

            mousePosition = new Point(Mouse.GetState().X, Mouse.GetState().Y);

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            mousePosition = new Point(Mouse.GetState().X, Mouse.GetState().Y);
            clickArea = BoardPosition.SelectArea(mousePosition);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !hare.Enable && !houndOne.Enable && userSelectionHarePositionArea.Contains(mousePosition))
            {
                hare.Enable = true;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !hare.Enable && !houndOne.Enable && userSelectionHoundPositionArea.Contains(mousePosition))
            {
                houndOne.Enable = true;
                houndTwo.Enable = true;
                houndThree.Enable = true;
            }

            
            if (hare.Enable)
            {
                hare.isClick(mousePosition);
                //Console.WriteLine("hare select {0}", hare.Selected);
                if (hare.Selected)
                {
                    if (BoardPosition.IsOccupy(hare, houndOne, houndTwo, houndThree, clickArea))
                    {
                        Console.WriteLine("hit area {0}", clickArea);
                        hare.Position = clickArea;
                        Console.WriteLine("hare area {0}", hare.Position);
                        //hare.Area = new Rectangle((int)hare.Position.X, (int)hare.Position.Y, 50, 50);
                        hare.Selected = false;
                    }

                }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            spriteBatch.Begin();

            spriteBatch.Draw(background, backgroundPosition, null, Color.BlanchedAlmond, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.Draw(hare.setImage, userSelectionHarePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(houndOne.setImage, userSelectionHoundPosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.Draw(hare.setImage, hare.Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(houndOne.setImage, houndOne.Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(houndOne.setImage, houndTwo.Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(houndOne.setImage, houndThree.Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.End();
            base.Draw(gameTime);

            
        }
    }
}
