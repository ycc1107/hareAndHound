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
        
        #region Private loactions

        private const float CENTER_X = 174;
        private const float CENTER_Y = 96;
        private const float FIRST_COLUMN_X = 282;
        private const float SECOND_COLUMN_X = 390;
        private const float THIRD_COLUMN_X = 490;
        private const float UP_Y = 0;
        private const float MID_Y = 108;
        private const float DOWN_Y = 212;

        private Vector2 board;
        private Vector2 left_end;
        private Vector2 first_column_up;
        private Vector2 first_column_mid;
        private Vector2 first_column_down;
        private Vector2 second_column_up;
        private Vector2 second_column_mid;
        private Vector2 second_column_down;
        private Vector2 third_column_up;
        private Vector2 third_column_mid;
        private Vector2 third_column_down;
        private Vector2 right_end;

        private Vector2 hare_select;
        private Vector2 hound_select;

        Rectangle left_end_area;
        Rectangle first_column_up_area;
        Rectangle first_column_mid_area;
        Rectangle first_column_down_area;
        Rectangle second_column_up_area;
        Rectangle second_column_mid_area;
        Rectangle second_column_down_area;
        Rectangle third_column_up_area;
        Rectangle third_column_mid_area;
        Rectangle third_column_down_area;
        Rectangle right_end_area;

        Rectangle hare_select_area;
        Rectangle hound_select_area;

        #endregion

        public BoardPosition ()
        {
           board = new Vector2(CENTER_X, UP_Y);  // board position

           left_end = new Vector2(CENTER_X, CENTER_Y + 12); // left end
           first_column_up  = new Vector2(FIRST_COLUMN_X, UP_Y);  // first column up
           first_column_mid = new Vector2(FIRST_COLUMN_X, MID_Y); // fist column mid
           first_column_down = new Vector2(FIRST_COLUMN_X, DOWN_Y); // first column down
           second_column_up = new Vector2(SECOND_COLUMN_X, UP_Y);  // second column up
           second_column_mid = new Vector2(SECOND_COLUMN_X, MID_Y); // second column mid
           second_column_down = new Vector2(SECOND_COLUMN_X, DOWN_Y); // second column down
           third_column_up = new Vector2(THIRD_COLUMN_X, UP_Y);  // third column up
           third_column_mid = new Vector2(THIRD_COLUMN_X, MID_Y); // third column mid
           third_column_down = new Vector2(THIRD_COLUMN_X, DOWN_Y); // third column down
           right_end = new Vector2(CENTER_X + 432, CENTER_Y + 11); // right end

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

           hare_select = new Vector2(FIRST_COLUMN_X, DOWN_Y + 150);
           hound_select = new Vector2(THIRD_COLUMN_X, DOWN_Y + 150);

           hare_select_area = new Rectangle((int)FIRST_COLUMN_X, (int)DOWN_Y + 150, 50, 50);
           hound_select_area = new Rectangle((int)THIRD_COLUMN_X, (int)DOWN_Y + 150, 50, 50);
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

        public Vector2 SelectArea(Point mousePosition)
        {
            Vector2 result = new Vector2(0,0);
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

        public bool IsOccupy(Animal hare,Animal hounOne,Animal houndTwo,Animal houndThree,Vector2 clickArea)
        {
            bool result = false;
            if(hare.Position.X == clickArea.X &&hare.Position.Y == clickArea.Y )
            {
                result = true;
            }

            if (hounOne.Position.X == clickArea.X && hounOne.Position.Y == clickArea.Y)
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


    }
}
