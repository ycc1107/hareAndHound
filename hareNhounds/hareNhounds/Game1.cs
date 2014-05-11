using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        SpriteFont font;
        
        Stopwatch stopwatch = new Stopwatch();
        protected string timeNeedForAI;
        protected string occuped;
        protected string Win = "";
        protected const string EASY_MODE = "EASY MODE";
        protected const string EXPERT_MODE = "EXPERT MODE";
        protected string mode = "";

        protected Texture2D background;

        protected Vector2 backgroundPosition;
        protected Vector2 userSelectionHarePosition;
        protected Vector2 userSelectionHoundPosition;
        protected Vector2 clickArea;

        protected Rectangle userSelectionHarePositionArea;
        protected Rectangle userSelectionHoundPositionArea;

        BoardPosition BoardPosition = new BoardPosition();

        Point mousePosition;

        bool hareMoved = false;
        bool houndMoved = false;

        private const int HARE_MOVE = 1;
        private const int HOUND_MOVE = 0;

        protected ClickableObjBase EasyMode = new ClickableObjBase();
        protected ClickableObjBase ExpertMode = new ClickableObjBase();

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

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("image/font");

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

            ExpertMode.Position = new Vector2(50, 50);
            EasyMode.Position = new Vector2(50, 150);
            ExpertMode.MovePosition = ExpertMode.Position;
            EasyMode.MovePosition = EasyMode.Position;
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

            //Console.WriteLine("the click area {0}", clickArea);

            #region mode select
            //Console.WriteLine("the EasyMode area {0}", EasyMode.Area);
            //Console.WriteLine("the mode enable {0}", EasyMode.Selected);
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !EasyMode.Enable && !ExpertMode.Enable)
            {
                EasyMode.isClick(mousePosition);
                ExpertMode.isClick(mousePosition);
                if (EasyMode.Selected)
                {
                    mode = EASY_MODE;
                }
                else if (ExpertMode.Selected)
                {
                    mode = EXPERT_MODE;
                }
            }
            #endregion

            #region Enable Player
            if (EasyMode.Selected || ExpertMode.Selected)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && !BoardPosition.hare.Enable && !BoardPosition.houndOne.Enable && userSelectionHarePositionArea.Contains(mousePosition))
                {
                    BoardPosition.hare.Enable = true;
                    
                    hareMoved = true;
                }

                if (Mouse.GetState().LeftButton == ButtonState.Pressed && !BoardPosition.hare.Enable && !BoardPosition.houndOne.Enable && userSelectionHoundPositionArea.Contains(mousePosition))
                {
                    BoardPosition.houndOne.Enable = true;
                }
            }
            #endregion

            //Console.WriteLine("the hare area {0}", BoardPosition.hare.Area);
            //timeNeedForAI = "No Move made";
            
            if (hareMoved || houndMoved)
            {
                stopwatch.Start();
                if (hareMoved)
                {
                    BoardPosition.AIMove(HOUND_MOVE, mode);
                    hareMoved = false;
                }
                else if (houndMoved)
                {
                    BoardPosition.AIMove(HARE_MOVE, mode);
                    houndMoved = false;
                }
                
                stopwatch.Stop();
                
                timeNeedForAI = Convert.ToString(stopwatch.Elapsed);
            }
            else
            {

                #region hare move
                if (BoardPosition.hare.Enable)
                {
                    if (!hareMoved)
                    {
                        BoardPosition.hare.Selected = true;
                    }
                    if (BoardPosition.IsHareWin())
                    {
                        Win = "YOU WIN THE GAME!"; 
                    }
                    else
                    {
                        if (BoardPosition.hare.Selected)
                        {
                            //occuped = Convert.ToString(BoardPosition.IsOccupied(clickArea));
                            if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHareLegalMove(clickArea))
                            {

                                BoardPosition.hare.MovePosition = clickArea;
                                BoardPosition.hare.Selected = false;
                                hareMoved = true;
                            }
                        }
                    }

                }

                #endregion 

                #region hound move
                if (BoardPosition.houndOne.Enable)
                {
                    if (BoardPosition.IsHoundWin())
                    {
                        Win = "YOU WIN THE GAME!";
                    }
                    else
                    {
                        if (houndSelected(mousePosition) == 1)
                        {

                            if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHoundLegalMove(clickArea, BoardPosition.houndOne.MovePosition))
                            {
                                BoardPosition.houndOne.MovePosition = clickArea;
                                BoardPosition.houndOne.Selected = false;
                                houndMoved = true;
                            }

                        }
                        else if (houndSelected(mousePosition) == 2)
                        {
                            if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHoundLegalMove(clickArea, BoardPosition.houndTwo.MovePosition))
                            {
                                BoardPosition.houndTwo.MovePosition = clickArea;
                                BoardPosition.houndTwo.Selected = false;
                                houndMoved = true;
                            }
                        }
                        else if (houndSelected(mousePosition) == 3)
                        {
                            if (!BoardPosition.IsOccupied(clickArea) && BoardPosition.IsHoundLegalMove(clickArea, BoardPosition.houndThree.MovePosition))
                            {
                                BoardPosition.houndThree.MovePosition = clickArea;
                                BoardPosition.houndThree.Selected = false;
                                houndMoved = true;
                            };
                        }
                    }
                }
                #endregion 

            }

        

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            spriteBatch.Begin();

            if (timeNeedForAI != null)
            {
                spriteBatch.DrawString(font, timeNeedForAI, new Vector2(390, 0), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }

            if (EasyMode.Selected)
            {
                spriteBatch.DrawString(font, EASY_MODE, new Vector2(350,50), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
            else if (ExpertMode.Selected)
            {
                spriteBatch.DrawString(font, EXPERT_MODE, new Vector2(350, 50), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.DrawString(font, EXPERT_MODE, ExpertMode.Position, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                spriteBatch.DrawString(font, EASY_MODE, EasyMode.Position, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

            }


            spriteBatch.DrawString(font, Win, new Vector2(390, 30), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

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

        private int houndSelected(Point mousePosition)
        {
            int result = 0;
            if (BoardPosition.houndOne.Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = 1;
            }
            else if(BoardPosition.houndTwo.Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = 2;
            }
            else if (BoardPosition.houndThree.Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = 3;
            }

            return result;
        }
    }
}
