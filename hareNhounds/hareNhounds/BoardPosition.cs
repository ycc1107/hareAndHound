﻿using System;
using System.Collections.Generic;
using System.Threading;
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

        #region Constant
        private const int SPREAD = 100;
        private const int HOUND_NUMBER = 3;

        private const int WIN = 1000;
        private const int GREAT_MOVE = 40;
        private const int BETTER_MOVE = 30;
        private const int GOOD_MOVE = 20;
        private const int NORMAL_MOVE = 20;
        private const int BAD_MOVE = -40;

        private const int HARE_MOVE = 1;
        private const int HOUND_MOVE = -1;


        private const int ANIMAL_INDEX_HARE = 1;
        private const int ANIMAL_INDEX_HOUND_ONE = 2;
        private const int ANIMAL_INDEX_HOUND_TWO = 3;
        private const int ANIMAL_INDEX_HOUND_THREE = 4;

        private const bool EVELUATION = false;

        protected const float CENTER_X = 174;
        protected const float CENTER_Y = 100;
        protected const float FIRST_COLUMN_X = 282;
        protected const float SECOND_COLUMN_X = 390;
        protected const float THIRD_COLUMN_X = 496;
        protected const float UP_Y = 100;
        protected const float MID_Y = UP_Y + 108;
        protected const float DOWN_Y = UP_Y + 212;

        protected const int DEPTH = 8;
        protected const int DEEPER = DEPTH +3;
        protected const int DEEPEST = DEEPER +3;

        protected const string EASY_MODE = "EASY MODE";
        protected const string EXPERT_MODE = "EXPERT MODE";

        #endregion

        public Animal hare;
        public Animal houndOne;
        public Animal houndTwo;
        public Animal houndThree;
            
        #region Protected 

        protected List<Animal> houndList;
        protected List<string> AIMoveList;
        //private const string BOUNS = "390208";
        protected int MoveCounter = 0;
        protected List<string> state = new List<string>();
        protected List<string> repeatMove = new List<string>();
        protected List<string> tempFile = new List<string>();
        int moveNumber = 1;

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

           left_end_area = new Rectangle((int)CENTER_X, (int)MID_Y , 50, 50);
           first_column_up_area = new Rectangle((int)FIRST_COLUMN_X, (int)UP_Y , 50, 50);
           first_column_mid_area = new Rectangle((int)FIRST_COLUMN_X, (int)MID_Y , 50, 50);
           first_column_down_area = new Rectangle((int)FIRST_COLUMN_X, (int)DOWN_Y , 50, 50);
           second_column_up_area = new Rectangle((int)SECOND_COLUMN_X, (int)UP_Y , 50, 50);
           second_column_mid_area = new Rectangle((int)SECOND_COLUMN_X, (int)MID_Y , 50, 50);
           second_column_down_area = new Rectangle((int)SECOND_COLUMN_X, (int)DOWN_Y , 50, 50);
           third_column_up_area = new Rectangle((int)THIRD_COLUMN_X, (int)UP_Y , 50, 50);
           third_column_mid_area = new Rectangle((int)THIRD_COLUMN_X, (int)MID_Y , 50, 50);
           third_column_down_area = new Rectangle((int)THIRD_COLUMN_X, (int)DOWN_Y , 50, 50);
           right_end_area = new Rectangle((int)CENTER_X + 432, (int)MID_Y , 50, 50);

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

        #region Get position in board

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

        #endregion 

        public void AIMove(int who, string mode)
        {
            int depth = DEPTH;
            int alpha = int.MinValue;
            int beta = int.MaxValue;

            hare.Position = hare.MovePosition;
            houndOne.Position = houndOne.MovePosition;
            houndTwo.Position = houndTwo.MovePosition;
            houndThree.Position = houndThree.MovePosition;

            //if (MoveCounter > 5)
                //depth = DEEPER;
            //if (MoveCounter > 10)
                //depth = DEEPEST;


            tempFile = new List<string>();
            state = new List<string>();
            AlphaBetaMax(depth, alpha, beta, who, mode);

            using (System.IO.StreamWriter file = System.IO.File.AppendText(@"C:\Users\galaxyan\Documents\GitHub\hareAndHound\WriteLines2.txt"))
            {
                file.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~{0}~~~~~~~~~~~~~The move counts {1}~~~~~~~~~~~~~~~~~~~~", moveNumber, tempFile.Count);
                if (moveNumber > 0)
                {
                    foreach (string line in tempFile)
                    {
                        file.WriteLine(line);
                    }
                }
                moveNumber += 1;
            }


            string newAIMove = AIMoveList.Last();

            //counter += 1;

            int animalIndex = Convert.ToInt32(newAIMove.Substring(6));
            float x = (float)Convert.ToInt32(newAIMove.Substring(0, 3));
            float y = (float)Convert.ToInt32(newAIMove.Substring(3, 3));
            Vector2 newPositon = new Vector2(x, y);


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


        }

        #region Position Related
        public Vector2 SelectArea(Point mousePosition,Vector2 lastClickArea)
        {
            Vector2 result = lastClickArea;
            if (!hare.Area.Contains(mousePosition) && !houndOne.Area.Contains(mousePosition) && !houndTwo.Area.Contains(mousePosition) && !houndThree.Area.Contains(mousePosition))
            {
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
            }
            return result;
        }

        public bool IsOccupied( Vector2 clickArea, bool play = true )
        {
            bool result = false;
            if (play)
            {
                if (hare.MovePosition.X == clickArea.X && hare.MovePosition.Y == clickArea.Y)
                {
                    result = true;
                }

                if (houndOne.MovePosition.X == clickArea.X && houndOne.MovePosition.Y == clickArea.Y)
                {
                    result = true;
                }

                if (houndTwo.MovePosition.X == clickArea.X && houndTwo.MovePosition.Y == clickArea.Y)
                {
                    result = true;
                }

                if (houndThree.MovePosition.X == clickArea.X && houndThree.MovePosition.Y == clickArea.Y)
                {
                    result = true;
                }
            }
            else
            {
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
            }

            return result;
        }

        public bool IsHareLegalMove(Vector2 clickArea)
        {
            bool result = false;
            if (Math.Abs(hare.MovePosition.X - clickArea.X) < 120 && Math.Abs(hare.MovePosition.Y - clickArea.Y) < 120)
            {
                if (!IsNonDiagonal(hare.MovePosition, clickArea))
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

        private string EncodeMove(Vector2 move, int animalIndex)
        {
            string result = "";

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                result = move.X.ToString() + move.Y.ToString() + animalIndex.ToString();
            }

            return result;
        }

        private Vector2 DecodeMove(string encodeMove)
        {
            Vector2 result = Vector2.Zero;

            result.X = (float)Convert.ToInt32(encodeMove.Substring(0, 3));
            result.Y = (float)Convert.ToInt32(encodeMove.Substring(3, 3));

            return result;
        }

        #endregion 

        public List<string> PossibleMove(int who, bool play = true)
        {
            List<string> result = new List<string>();
            List<string> removeList = new List<string>();
            int animalIndex = 1;
            if (play)
            {
                hare.Position = hare.MovePosition;
                houndOne.Position = houndOne.MovePosition;
                houndTwo.Position = houndTwo.MovePosition;
                houndThree.Position = houndThree.MovePosition;
            }

            if (who == HARE_MOVE)
            {

                #region Set Hare Possible

                    if (hare.Position == FIRST_COLUMN_UP)
                    {
                        result.Add(EncodeMove(LEFT_END, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                    }
                    else if (hare.Position == FIRST_COLUMN_MID)
                    {
                        result.Add(EncodeMove(LEFT_END, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                    }
                    else if (hare.Position == FIRST_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(LEFT_END, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_UP)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP, animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_MID)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP, animalIndex));
                    }
                    else if (hare.Position == SECOND_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(FIRST_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_UP)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_MID)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                    else if (hare.Position == THIRD_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(SECOND_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(SECOND_COLUMN_DOWN, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(RIGHT_END, animalIndex));
                    }
                    else if (hare.Position == RIGHT_END)
                    {
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_UP, animalIndex));
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                    
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
                    }
                    else if (hound.Position == THIRD_COLUMN_MID)
                    {
                       
                        result.Add(EncodeMove(THIRD_COLUMN_DOWN, animalIndex));
                    }
                    else if (hound.Position == THIRD_COLUMN_DOWN)
                    {
                        result.Add(EncodeMove(THIRD_COLUMN_MID, animalIndex));
                    }
                }

                result = result.Distinct().ToList();
                #endregion
            }

            for(int i = 0 ; i< result.Count;i++)
            {

                if (IsOccupied(DecodeMove(result[i]), EVELUATION))
                {
                    removeList.Add(result[i]);
                }
            }
            foreach (string removeItem in removeList)
            {
                result.Remove(removeItem);
            }

            return result;
        }

        #region Evaulation 

        private int Evaluation(int who,string mode)
        {
            int result = 0;
            if (who == HARE_MOVE)
            {
                result = HareAdvantage(mode);// -HoundAdvantage(mode);
            }
            else
            {

                result = HoundAdvantage(mode);// -HareAdvantage(mode);
            }

            return  result;
        }

        private int HareAdvantage(string mode)
        {
            int result = 0;
            int addScore = 0;
            float lastHoundPosition = Math.Min(houndOne.Position.X, Math.Min(houndThree.Position.X, houndTwo.Position.X));
            double dist = (Math.Sqrt(Math.Pow((houndOne.Position.X - hare.Position.X), 2) + Math.Pow((houndOne.Position.Y - hare.Position.Y), 2)) +
                            Math.Sqrt(Math.Pow((houndTwo.Position.X - hare.Position.X), 2) + Math.Pow((houndTwo.Position.Y - hare.Position.Y), 2)) +
                            Math.Sqrt(Math.Pow((houndThree.Position.X - hare.Position.X), 2) + Math.Pow((houndThree.Position.Y - hare.Position.Y), 2))) / 3;

            if (hare.Position.X <= lastHoundPosition)
            {
                result = WIN;
            }
            else if (hare.Position.X <= FIRST_COLUMN_X)
            {
                addScore += Convert.ToInt32(Convert.ToDouble(GREAT_MOVE) * 50/ dist);
            }if(hare.Position.X <= SECOND_COLUMN_X)
            {
                addScore += Convert.ToInt32(Convert.ToDouble(BETTER_MOVE) * 50 / dist); 
            }
            else if (hare.Position.X <= THIRD_COLUMN_X)
            {
                addScore += Convert.ToInt32(Convert.ToDouble(GOOD_MOVE) * 50 / dist);
            }

            result += addScore;
            return result;
        }

        // distance between hare and hounds should be small
        // hounds position should be limited to exceed hare position
        private int HoundAdvantage(string mode)
        {
           
            int result = 0;
            int addScore = 0;
            double dist = Math.Abs((3 * hare.Position.X - (houndOne.Position.X + houndTwo.Position.X + houndThree.Position.X)) / 3 );
            double houndDist = (houndOne.Position.X + houndTwo.Position.X + houndThree.Position.X) - 3 * LEFT_END.X;

            //Console.WriteLine(" the distance {0}       {1}", dist,houndDist);
            if (PossibleMove(HARE_MOVE, false).Count == 0)
            {
                result = WIN;
            }
            else
            {
                if(dist <= 10)
                {
                    addScore += GREAT_MOVE;
                }
                if (dist <= 110)
                {
                    addScore += BETTER_MOVE;
                }
                else if (dist <= 220)
                {
                    addScore += NORMAL_MOVE;
                }
                else if (dist <= 330)
                {
                    addScore += BAD_MOVE;
                }

                if (houndOne.Position.X >= hare.Position.X || houndTwo.Position.X >= hare.Position.X || houndThree.Position.X >= hare.Position.X)
                {
                    addScore += BAD_MOVE;
                }
                if (houndDist > 220)
                {
                    addScore += BAD_MOVE;
                }
            }
            result += addScore;
            return result;
        }

        private int BoardValue(Vector2 position)
        {
            int result = 0;
            if (position == LEFT_END)
            {
                result = 5;
            }
            else if (position == FIRST_COLUMN_DOWN || position == FIRST_COLUMN_UP)
            {
                result = 3;
            }
            else if (position == SECOND_COLUMN_DOWN || position == SECOND_COLUMN_UP || position == THIRD_COLUMN_MID)
            {
                result = 1;
            }
            else if (position == THIRD_COLUMN_DOWN || position == THIRD_COLUMN_UP)
            {
                result = 0;
            }
            else if (position == FIRST_COLUMN_MID)
            {
                result = 4;
            }
            else if (position == SECOND_COLUMN_MID)
            {
                result = 2;
            }
            else if (position == RIGHT_END)
            {
                result = -1;
            }

            return result;
        }

        public bool IsHareWin()
        {
            bool result = false;

            float lastHoundPosition = Math.Min(houndOne.MovePosition.X, Math.Min(houndThree.MovePosition.X, houndTwo.MovePosition.X));
            if (hare.MovePosition.X <= lastHoundPosition)
                result = true;

            return result;
        }

        public bool IsHoundWin()
        {
            bool result = false;
            if (PossibleMove(HARE_MOVE).Count == 0)
                result = true;

            return result;
        }

        // Implement 3 mod theory 
        // Add all posiitions value moded by 3, if the result is 0 , it is a weak spot
        //      3 -- 1 -- 0 
        // 5 -- 4 -- 2 -- 1 -- -1  
        //      3 -- 1 -- 0
        //
        //      Z -- W -- Z 
        // S -- T -- S -- T -- S  
        //      Z -- W -- Z
        //
        // W : weak position should be avoid
        // S : strong position should be occpied
        //
        private int MoveEvaulation(string mode,string move)
        {
            int result = 0;
            if (mode == EXPERT_MODE)
            {
                int who = Convert.ToInt32(move.Substring(6));
                int threeModSocre = (BoardValue(hare.Position) + BoardValue(houndOne.Position) + BoardValue(houndTwo.Position) + BoardValue(houndThree.Position)) % 3;
                if (threeModSocre == 3)
                {
                    result += BAD_MOVE;
                }
                else if (threeModSocre == 2 && threeModSocre == 1)
                {
                    result += NORMAL_MOVE;
                }

                if (who == ANIMAL_INDEX_HARE)
                {
                    if (hare.Position == SECOND_COLUMN_MID || hare.Position == RIGHT_END || hare.Position == LEFT_END)
                    {
                        result += GREAT_MOVE;
                    }
                    if (hare.Position == SECOND_COLUMN_DOWN || hare.Position == SECOND_COLUMN_UP)
                    {
                        result += BAD_MOVE;
                    }
                }
                else
                {
                    if (houndOne.Position == SECOND_COLUMN_MID || houndTwo.Position == SECOND_COLUMN_MID || houndThree.Position == SECOND_COLUMN_MID)
                    {
                        result += GREAT_MOVE;
                    }
                    if (houndOne.Position == SECOND_COLUMN_DOWN || houndOne.Position == SECOND_COLUMN_UP || houndTwo.Position == SECOND_COLUMN_DOWN || houndTwo.Position == SECOND_COLUMN_UP || houndThree.Position == SECOND_COLUMN_DOWN || houndThree.Position == SECOND_COLUMN_UP)
                    {
                        result += BAD_MOVE;
                    }
                    if (who == ANIMAL_INDEX_HOUND_ONE && houndOne.Position.X > houndTwo.Position.X + SPREAD && houndOne.Position.X > houndThree.Position.X + SPREAD)
                    {
                        result += BAD_MOVE;
                    }
                    if (who == ANIMAL_INDEX_HOUND_TWO && houndTwo.Position.X > houndOne.Position.X + SPREAD && houndTwo.Position.X > houndThree.Position.X + SPREAD)
                    {
                        result += BAD_MOVE;
                    }
                    if (who == ANIMAL_INDEX_HOUND_THREE && houndThree.Position.X > houndTwo.Position.X + SPREAD && houndThree.Position.X > houndOne.Position.X + SPREAD)
                    {
                        result += BAD_MOVE;
                    }

                }
              }
            return result;
          }
        

        #endregion 

        private void MoveAnimal(string move)
        {
            int animalIndex = Convert.ToInt32(move.Substring(6));
            Vector2 tempPositionStorage = Vector2.Zero;
            float x = (float)Convert.ToInt32(move.Substring(0, 3));
            float y = (float)Convert.ToInt32(move.Substring(3, 3));
            Vector2 newPositon = new Vector2(x, y);

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                tempPositionStorage = hare.Position;
                hare.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                tempPositionStorage = houndOne.Position;
                houndOne.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                tempPositionStorage = houndTwo.Position;
                houndTwo.Position = newPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                tempPositionStorage = houndThree.Position;
                houndThree.Position = newPositon;
            }
            state.Add(EncodeMove(tempPositionStorage, animalIndex));
        }

        private void UndoMove()
        {
            string image = state.Last();
            state.RemoveAt(state.Count - 1);
            int animalIndex = Convert.ToInt32(image.Substring(6));
            float x = (float)Convert.ToInt32(image.Substring(0, 3));
            float y = (float)Convert.ToInt32(image.Substring(3, 3));
            Vector2 oldPositon = new Vector2(x, y);

            if (animalIndex == ANIMAL_INDEX_HARE)
            {
                hare.Position = oldPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_ONE)
            {
                houndOne.Position = oldPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_TWO)
            {
                houndTwo.Position = oldPositon;
            }
            else if (animalIndex == ANIMAL_INDEX_HOUND_THREE)
            {
                houndThree.Position = oldPositon;
            }
            
        }

        private int AlphaBetaMin(int depth, int alpha, int beta, int who, string mode)
        {
            List<string> listMove = PossibleMove(who,false);

            if (depth == 0 || listMove.Count == 0 || IsHareWin())
            {
                //nsole.WriteLine("depth {0}", depth);
                return who*Evaluation(who, mode);
            }
            int score = int.MaxValue;

            who = -1 * who;
            foreach (string move in listMove)
            {
                
                //if (StageImage())
                    //continue;
                MoveAnimal(move);
                score = Math.Min(score, AlphaBetaMax(depth - 1, alpha, beta, who, mode));
                int valueAdd = MoveEvaulation(mode, move);
                score += valueAdd;

                string temp = "Depth: " + Convert.ToString(depth) + ",Score :" + Convert.ToString(Evaluation(who, mode)) + ", AB Pruning Stage :MAX" + ",Who: " + who + ",Move :" + move;
                tempFile.Add(temp);
                UndoMove();
                if (score <= alpha)
                {
                    score -= valueAdd;
                    return alpha;
                }
                if (score < beta)
                {
                    beta = score;
                    score -= valueAdd;
                }

            }
            return beta;
        } 

        private int AlphaBetaMax(int depth, int alpha, int beta, int who,string mode)
        {
            List<string> listMove = PossibleMove(who, false);
            string bestMove = "";

            if (depth == 0 || listMove.Count == 0 || IsHareWin())
            {
                //Console.WriteLine("depth {0}", depth);
                return who * Evaluation(who, mode);
            }


            who = -1 * who;
            int score = int.MinValue;
            foreach (string move in listMove)
            {
                MoveAnimal(move);
                //Console.WriteLine("the depht numbner {0}",depth);
                score = Math.Max(score, AlphaBetaMin(depth - 1, alpha, beta, who, mode));
                int valueAdd = MoveEvaulation(mode, move);
                score += valueAdd; 

                string temp = "Depth: " + Convert.ToString(depth) + ",Score :" + Convert.ToString(Evaluation(who, mode)) + ", AB Pruning Stage :MAX" + ",Who: " + who + ",Move :" + move;
                tempFile.Add(temp);

                UndoMove();
                if (score >= beta)
                {
                    score -= valueAdd;
                    return beta;
                }
                if (score > alpha)
                {
                    alpha = score;
                    score -= valueAdd;
                    bestMove = move;
                }

            }
            AIMoveList.Add(bestMove);
            return alpha;

        }

        #endregion

        



    }
}
