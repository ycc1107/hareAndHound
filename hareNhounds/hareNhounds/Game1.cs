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

        private const int HARE_MOVE = 1;
        private const int HOUND_MOVE = 0;

        //Animal hare;
        //Animal houndOne;
        //Animal houndTwo;
        //Animal houndThree;
        Animal hound;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

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

            

            background = Content.Load<Texture2D>("image/Hare_and_Hounds_board");
            backgroundPosition = BoardPosition.BOARD;

            userSelectionHarePosition = BoardPosition.HARE_SELECT;
            userSelectionHoundPosition = BoardPosition.HOUND_SELECT;

            userSelectionHarePositionArea = new Rectangle((int)userSelectionHarePosition.X,(int)userSelectionHarePosition.Y,50,50);
            userSelectionHoundPositionArea = new Rectangle((int)userSelectionHoundPosition.X, (int)userSelectionHoundPosition.Y,50,50);

            BoardPosition.hare.setImage = Content.Load<Texture2D>("image/hare");
            BoardPosition.hare.Position = BoardPosition.RIGHT_END;
            BoardPosition.hare.MovePosition = BoardPosition.RIGHT_END;

            BoardPosition.houndOne.setImage = Content.Load<Texture2D>("image/hound");
            BoardPosition.houndOne.Position = BoardPosition.FIRST_COLUMN_UP;
            BoardPosition.houndOne.MovePosition = BoardPosition.FIRST_COLUMN_UP;

            BoardPosition.houndTwo.Position = BoardPosition.LEFT_END;
            BoardPosition.houndTwo.MovePosition = BoardPosition.LEFT_END;

            BoardPosition.houndThree.Position = BoardPosition.FIRST_COLUMN_DOWN;
            BoardPosition.houndThree.MovePosition = BoardPosition.FIRST_COLUMN_DOWN;

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
            clickArea = BoardPosition.SelectArea(mousePosition,clickArea);

            #region Enable Player
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !BoardPosition.hare.Enable && !BoardPosition.houndOne.Enable && userSelectionHarePositionArea.Contains(mousePosition))
            {
                BoardPosition.hare.Enable = true;
            }

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !BoardPosition.hare.Enable && !BoardPosition.houndOne.Enable && userSelectionHoundPositionArea.Contains(mousePosition))
            {
                BoardPosition.houndOne.Enable = true;
            }
            #endregion


            if (BoardPosition.hare.Enable)
            {
                BoardPosition.hare.isClick(mousePosition);
                //Console.WriteLine("hare select {0}", hare.Selected);
                if (BoardPosition.hare.Selected)
                {
                    if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHareLegalMove(clickArea))
                    {
                        BoardPosition.hare.MovePosition = clickArea;
                        BoardPosition.hare.Selected = false;
                        BoardPosition.AIMove(HOUND_MOVE);
                        Console.WriteLine("moving possiton {0}", BoardPosition.hare.MovePosition);
                        //BoardPosition.AlphaBeta(10, -1, 2, true, hare, houndOne, houndTwo, houndThree, clickArea, false);
                    }
                }

            }


            if (BoardPosition.houndOne.Enable)
            {
                BoardPosition.houndOne.isClick(mousePosition);
                BoardPosition.houndTwo.isClick(mousePosition);
                BoardPosition.houndThree.isClick(mousePosition);

                if (BoardPosition.houndOne.Selected)
                {
                    hound = BoardPosition.houndOne;
                    BoardPosition.houndOne.Selected = false;
                }
                else if (BoardPosition.houndOne.Selected)
                {
                    hound = BoardPosition.houndTwo;
                    BoardPosition.houndTwo.Selected = false;
                }
                else if (BoardPosition.houndOne.Selected)
                {
                    hound = BoardPosition.houndThree;
                    BoardPosition.houndThree.Selected = false;
                }
                
                if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHoundLegalMove(clickArea, hound.Position))
                {
                    BoardPosition.houndOne.Position = clickArea;
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            spriteBatch.Begin();

            spriteBatch.Draw(background, backgroundPosition, null, Color.BlanchedAlmond, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.Draw(BoardPosition.hare.setImage, userSelectionHarePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(BoardPosition.houndOne.setImage, userSelectionHoundPosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.Draw(BoardPosition.hare.setImage, BoardPosition.hare.MovePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(BoardPosition.houndOne.setImage, BoardPosition.houndOne.MovePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(BoardPosition.houndOne.setImage, BoardPosition.houndTwo.MovePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.Draw(BoardPosition.houndOne.setImage, BoardPosition.houndThree.MovePosition, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            spriteBatch.End();
            base.Draw(gameTime);

            
        }
    }
}
