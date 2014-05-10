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
    public class BoardPosition
    {

        private const int HOUND_NUMBER = 3;
        private List<Animal> houndList;

        #region TempAdd

        public Animal hare;
        public Animal houndOne;
        public Animal houndTwo;
        public Animal houndThree;

        private List<string> AIMoveList;
        private int score;

        private const int HARE_WIN = 1;
        private const int HOUND_WIN = -1;
        private const int HARE_MOVE = 1;
        private const int HOUND_MOVE = 0;


        private const int ANIMAL_INDEX_HARE = 1;
        private const int ANIMAL_INDEX_HOUND_ONE = 2;
        private const int ANIMAL_INDEX_HOUND_TWO = 3;
        private const int ANIMAL_INDEX_HOUND_THREE = 4;

        private string bestMove;
        #endregion 


            
        #region Private loactions

        protected const float CENTER_X = 174;
        protected const float CENTER_Y = 100;
        protected const float FIRST_COLUMN_X = 282;
        protected const float SECOND_COLUMN_X = 390;
        protected const float THIRD_COLUMN_X = 496;
        protected const float UP_Y = 100;
        protected const float MID_Y = UP_Y+108;
        protected const float DOWN_Y = UP_Y+212;

        protected Vector2 board;
        protected Vector2 left_end;
        protected Vector2 first_column_up;
        protected Vector2 first_column_mid;
        protected Vector2 first_column_down;
        protected Vector2 second_column_up;
        protected Vector2 second_column_mid;
        protected Vector2 second_column_down;
        protected Vector2 third_column_up;
        protected Vector2 third_column_mid;
        protected Vector2 third_column_down;
        protected Vector2 right_end;

        protected Vector2 hare_select;
        protected Vector2 hound_select;

        protected Rectangle left_end_area;
        protected Rectangle first_column_up_area;
        protected Rectangle first_column_mid_area;
        protected Rectangle first_column_down_area;
        protected Rectangle second_column_up_area;
        protected Rectangle second_column_mid_area;
        protected Rectangle second_column_down_area;
        protected Rectangle third_column_up_area;
        protected Rectangle third_column_mid_area;
        protected Rectangle third_column_down_area;
        protected Rectangle right_end_area;

        protected Rectangle hare_select_area;
        protected Rectangle hound_select_area;

        protected List<Vector2> PostionList = new List<Vector2>();

        #endregion

        #region Public Methods

        public BoardPosition ()
        {
           board = new Vector2(CENTER_X, UP_Y);  // board position

           left_end = new Vector2(CENTER_X, MID_Y); // left end
           first_column_up  = new Vector2(FIRST_COLUMN_X, UP_Y);  // first column up
           first_column_mid = new Vector2(FIRST_COLUMN_X, MID_Y); // fist column mid
           first_column_down = new Vector2(FIRST_COLUMN_X, DOWN_Y); // first column down
           second_column_up = new Vector2(SECOND_COLUMN_X, UP_Y);  // second column up
           second_column_mid = new Vector2(SECOND_COLUMN_X, MID_Y); // second column mid
           second_column_down = new Vector2(SECOND_COLUMN_X, DOWN_Y); // second column down
           third_column_up = new Vector2(THIRD_COLUMN_X, UP_Y);  // third column up
           third_column_mid = new Vector2(THIRD_COLUMN_X, MID_Y); // third column mid
           third_column_down = new Vector2(THIRD_COLUMN_X, DOWN_Y); // third column down
           right_end = new Vector2(CENTER_X + 432, MID_Y); // right end

           left_end_area = new Rectangle((int)CENTER_X, (int)CENTER_Y + 12,50,50);
           first_column_up_area = new Rectangle((int)FIRST_COLUMN_X, (int)UP_Y + 12, 50, 50);
           first_column_mid_area = new Rectangle((int)FIRST_COLUMN_X, (int)MID_Y + 12, 50, 50);
           first_column_down_area = new Rectangle((int)FIRST_COLUMN_X, (int)DOWN_Y + 12, 50, 50);
           second_column_up_area = new Rectangle((int)SECOND_COLUMN_X, (int)UP_Y + 12, 50, 50);
           second_column_mid_area = new Rectangle((int)SECOND_COLUMN_X, (int)MID_Y + 12, 50, 50);
           second_column_down_area = new Rectangle((int)SECOND_COLUMN_X, (int)DOWN_Y + 12, 50, 50);
           third_column_up_area = new Rectangle((int)THIRD_COLUMN_X, (int)UP_Y + 12, 50, 50);
           third_column_mid_area = new Rectangle((int)THIRD_COLUMN_X, (int)MID_Y + 12, 50, 50);
           third_column_down_area = new Rectangle((int)THIRD_COLUMN_X, (int)DOWN_Y + 12, 50, 50);
           right_end_area = new Rectangle((int)CENTER_X + 432, (int)CENTER_Y + 11, 50, 50);

           hare_select = new Vector2(FIRST_COLUMN_X, DOWN_Y + 80);
           hound_select = new Vector2(THIRD_COLUMN_X, DOWN_Y + 80);

           hare_select_area = new Rectangle((int)FIRST_COLUMN_X, (int)DOWN_Y + 80, 50, 50);
           hound_select_area = new Rectangle((int)THIRD_COLUMN_X, (int)DOWN_Y + 80, 50, 50);

           PostionList.Add(this.LEFT_END);
           PostionList.Add(this.FIRST_COLUMN_UP);
           PostionList.Add(this.FIRST_COLUMN_MID);
           PostionList.Add(this.FIRST_COLUMN_DOWN);
           PostionList.Add(this.SECOND_COLUMN_UP);
           PostionList.Add(this.SECOND_COLUMN_MID);
           PostionList.Add(this.SECOND_COLUMN_DOWN);
           PostionList.Add(this.THIRD_COLUMN_UP);
           PostionList.Add(this.THIRD_COLUMN_MID);
           PostionList.Add(this.THIRD_COLUMN_DOWN);
           PostionList.Add(this.RIGHT_END);

           hare = new Hare();
           houndOne = new Hound();
           houndTwo = new Hound();
           houndThree = new Hound();

           houndList = new List<Animal>()
            {
                houndOne,
                houndTwo,
                houndThree
            };

           AIMoveList = new List<string>();


        }

        public Vector2 BOARD { get { return board; } }
        public Vector2 LEFT_END { get { return left_end; } }
        public Vector2 FIRST_COLUMN_UP { get { return first_column_up; } }
        public Vector2 FIRST_COLUMN_MID { get { return first_column_mid; } }
        public Vector2 FIRST_COLUMN_DOWN { get { return first_column_down; } }
        public Vector2 SECOND_COLUMN_UP { get { return second_column_up; } }
        public Vector2 SECOND_COLUMN_MID { get { return second_column_mid; } }
        public Vector2 SECOND_COLUMN_DOWN { get { return second_column_down; } }
        public Vector2 THIRD_COLUMN_UP { get { return third_column_up; } }
        public Vector2 THIRD_COLUMN_MID { get { return third_column_mid; } }
        public Vector2 THIRD_COLUMN_DOWN { get { return third_column_down; } }
        public Vector2 RIGHT_END { get { return right_end; } }

        public Rectangle LEFT_END_Area { get { return left_end_area; } }
        public Rectangle FIRST_COLUMN_UP_Area { get { return first_column_up_area; } }
        public Rectangle FIRST_COLUMN_MID_Area { get { return first_column_mid_area; } }
        public Rectangle FIRST_COLUMN_DOWN_Area { get { return first_column_down_area; } }
        public Rectangle SECOND_COLUMN_UP_Area { get { return second_column_up_area; } }
        public Rectangle SECOND_COLUMN_MID_Area { get { return second_column_mid_area; } }
        public Rectangle SECOND_COLUMN_DOWN_Area { get { return second_column_down_area; } }
        public Rectangle THIRD_COLUMN_UP_Area { get { return third_column_up_area; } }
        public Rectangle THIRD_COLUMN_MID_Area { get { return third_column_mid_area; } }
        public Rectangle THIRD_COLUMN_DOWN_Area { get { return third_column_down_area; } }
        public Rectangle RIGHT_END_Area { get { return right_end_area; } }

        public Vector2 HARE_SELECT { get { return hare_select; } }
        public Vector2 HOUND_SELECT { get { return hound_select; } }

        public Rectangle HARE_SELECT_AREA { get { return hare_select_area; } }
        public Rectangle HOUND_SELECT_AREA { get { return hound_select_area; } }

        public Vector2 SelectArea(Point mousePosition,Vector2 lastClickArea)
        {
            Vector2 result = lastClickArea;
            if (this.LEFT_END_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = LEFT_END;
            }

            if (this.FIRST_COLUMN_UP_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = FIRST_COLUMN_UP;
            }

            if (this.FIRST_COLUMN_MID_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = FIRST_COLUMN_MID;
            }

            if (this.FIRST_COLUMN_DOWN_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = FIRST_COLUMN_DOWN;
            }

            if (this.SECOND_COLUMN_UP_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = SECOND_COLUMN_UP;
            }

            if (this.SECOND_COLUMN_MID_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = SECOND_COLUMN_MID;
            }

            if (this.SECOND_COLUMN_DOWN_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = SECOND_COLUMN_DOWN;
            }

            if (this.THIRD_COLUMN_UP_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = THIRD_COLUMN_UP;
            }

            if (this.THIRD_COLUMN_MID_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = THIRD_COLUMN_MID;
            }

            if (this.THIRD_COLUMN_DOWN_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = THIRD_COLUMN_DOWN;
            }

            if (this.RIGHT_END_Area.Contains(mousePosition) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                result = RIGHT_END;
            }

            return result;
        }

        public bool IsOccupied( Vector2 clickArea)
        {
            bool result = false;
            if (hare.Position.X == clickArea.X && hare.Position.Y == clickArea.Y)
            {
                result = true;
            }

            if (houndOne.Position.X == clickArea.X && houndOne.Position.Y == clickArea.Y)
            {
                result = true;
            }

            if (houndTwo.Position.X == clickArea.X && houndTwo.Position.Y == clickArea.Y)
            {
                result = true;
            }

            if (houndThree.Position.X == clickArea.X && houndThree.Position.Y == clickArea.Y)
            {
                result = true;
            }

            return result;
        }

        public bool IsHareLegalMove(Vector2 clickArea)
        {
            bool result = false;
            if (Math.Abs(hare.Position.X - clickArea.X) < 120 && Math.Abs(hare.Position.Y - clickArea.Y) < 120)
            {
                if (!IsNonDiagonal(hare.Position, clickArea))
                {
                    result = true;

                }
            }

            return result;
        }

        public bool IsHoundLegalMove(Vector2 clickArea, Vector2 selectedHoundPostion)
        {
            bool result = false;

            if (selectedHoundPostion.X <= clickArea.X && Math.Abs(selectedHoundPostion.Y - clickArea.Y) < 120)
            {
                if (!IsNonDiagonal(selectedHoundPostion, clickArea))
                {
                    result = true;

                }

            }
            return result;
        }

        private bool IsNonDiagonal(Vector2 position, Vector2 clickArea)
        {
            bool result = false;
            if (position == this.FIRST_COLUMN_MID || position == this.SECOND_COLUMN_UP || position == this.SECOND_COLUMN_DOWN || position == this.THIRD_COLUMN_MID)
            {
                if (Math.Abs(position.X - clickArea.X) > 20 && Math.Abs(position.Y - clickArea.Y) > 20)
                {
                    result = true;
                }
            }
            return result;
        }

        public List<string> PossibleMove(int who)
        {
            List<string> result = new List<string>();
            int animalIndex = 1;

            if (who == HARE_MOVE)
            {

                #region Set Hare Possible
      
                    if (hare.Position == FIRST_COLUMN_UP)
                    {
                        result.Add(EncodeMove(LEFT_END,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hare.Position == FIRST_COLUMN_MID)
                    {
                        result.Add(EncodeMove(LEFT_END,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hare.Position == FIRST_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(LEFT_END,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_UP)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP,animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_MID)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP,animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_UP)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(RIGHT_END,animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_MID)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(RIGHT_END,animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(RIGHT_END,animalIndex));
                    }
                    else if (hare.Position == RIGHT_END)
                    {
                        result.Add(EncodeMove(THIRD_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));

                    }

                    #endregion
                
            }
            else
            {
                #region Set Hound Possible
                foreach(Animal hound in houndList )
                {
                    animalIndex += 1;

                    if (hound.Position == LEFT_END)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN,animalIndex));
                    }
                    else if (hound.Position == FIRST_COLUMN_UP)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hound.Position == FIRST_COLUMN_MID)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hound.Position == FIRST_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                    }
                    else if (hound.Position == SECOND_COLUMN_UP)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP,animalIndex));
                    }
                    else if (hound.Position == SECOND_COLUMN_MID)
                    {
                      
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP,animalIndex));
                    }
                    else if (hound.Position == SECOND_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID,animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN,animalIndex));
                    }
                    else if (hound.Position == THIRD_COLUMN_UP)
                    {
                        
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                    else if (hound.Position == THIRD_COLUMN_MID)
                    {
                       
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                    else if (hound.Position == THIRD_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                }

                result = result.Distinct().ToList();
                #endregion
            }

            for(int i = 0 ; i< result.Count;i++)
            {
               
                if (IsOccupied(DecodeMove(result[i])))
                {
                    result.Remove(result[i]);
                }
            }

            return result;
        }

        public void AIMove(int who)
        {
            //this.AlphaBeta
            int depth = 3;
            int alpha = int.MinValue;
            int beta = int.MaxValue;

            hare.Position = hare.MovePosition;
            houndOne.Position = houndOne.MovePosition;
            houndTwo.Position = houndTwo.MovePosition;
            houndThree.Position = houndThree.MovePosition;

            AlphaBetaMax(depth, alpha, beta, who);

            string bestMove = AIMoveList[0];
            int animalIndex =Convert.ToInt32(bestMove.Substring(6));
            float x = (float) Convert.ToInt32(bestMove.Substring(0,3));
            float y = (float) Convert.ToInt32(bestMove.Substring(3,3));
            Vector2 newPositon = new Vector2(x,y);

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                hare.MovePosition = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                houndOne.MovePosition = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                houndTwo.MovePosition = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                houndThree.MovePosition = newPositon;
            }
            Console.WriteLine("the new move {0} , who is moving {1}", newPositon,animalIndex);
            Console.WriteLine("##############################################");

            
        }

        private int Eveluation(int who)
        {
            int result = 0;
            if (who == HARE_MOVE)
            {
                float lastHoundPosition = Math.Min(houndOne.Position.X, Math.Min(houndThree.Position.X, houndTwo.Position.X));
                if (hare.Position.X >= lastHoundPosition)
                {
                    result = HARE_WIN;
                }
            }
            else
            {
                if ( PossibleMove(HARE_MOVE).Count == 0)
                {
                    result = HOUND_WIN;
                }
            }

            return  result;
            
        }
        private void MoveAnimal(string move)
        {
            int animalIndex = Convert.ToInt32(move.Substring(6));
            float x = (float)Convert.ToInt32(move.Substring(0, 3));
            float y = (float)Convert.ToInt32(move.Substring(3, 3));
            Vector2 newPositon = new Vector2(x, y);

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                hare.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                houndOne.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                houndTwo.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                houndThree.Position = newPositon;
            }

        }

        private int AlphaBetaMin(int depth, int alpha, int beta, int who)
        {
            List<string> listMove = PossibleMove(who);

            if (depth == 0 || listMove.Count == 0)
                return Eveluation(who);

            foreach (string move in listMove)
            {
                who = 1 - who;
                MoveAnimal(move);

                score = AlphaBetaMax(depth - 1, alpha, beta, who);
                if(  score <= alpha )
                     return alpha;
                if (score < beta)
                {
                    beta = score;
                    bestMove = move;
                }
                
           }
            AIMoveList.Add(bestMove);
            return beta;
        }

        private int AlphaBetaMax(int depth, int alpha, int beta, int who)
        {
             List<string> listMove = PossibleMove(who);

            if (depth == 0 || listMove.Count == 0)
                return Eveluation(who);

            foreach (string move in listMove)
            {
                who = 1 - who;
                MoveAnimal(move);

                score = AlphaBetaMin(depth - 1, alpha, beta,who);
                if (score >= beta)
                    return beta;
                if (score > alpha)
                {
                    alpha = score;
                    bestMove = move;
                    
                }
              
            }
            AIMoveList.Add(bestMove);
            return alpha;

        }

        #endregion

        private string EncodeMove(Vector2 move, int animalIndex)
        {
            string result = "";

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if(animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if(animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if(animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }

            return result;
        }

        private Vector2 DecodeMove(string encode)
        {
            Vector2 result = Vector2.Zero;

            result.X = (float)Convert.ToInt32(encode.Substring(0, 3));
            result.Y = (float)Convert.ToInt32(encode.Substring(3, 3));

            return result;
        }
     

    }
}
