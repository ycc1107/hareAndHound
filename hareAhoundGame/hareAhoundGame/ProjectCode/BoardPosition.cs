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

namespace hareAhoundGame.ProjectCode
{
    public static class BoardPosition 
    {
            private const float CENTER_X = 174;
            private const float CENTER_Y = 96;
            private const float FIRST_COLUMN_X = 282;
            private const float SECOND_COLUMN_X = 387;
            private const float THIRD_COLUMN_X = 472;
            private const float UP_Y = 0;
            private const float MID_Y = 108;
            private const float DOWN_Y = 212;

            public static Vector2 BOARD = new Vector2(CENTER_X, UP_Y);  // board position

            public static Vector2 LEFT_END = new Vector2(CENTER_X, CENTER_Y+ 12); // left end

            public static Vector2 FIRST_COLUMN_UP = new Vector2(FIRST_COLUMN_X, UP_Y);  // first column up
            public static Vector2 FIRST_COLUMN_MID = new Vector2(FIRST_COLUMN_X, MID_Y); // fist column mid
            public static Vector2 FIRST_COLUMN_DOWN = new Vector2(FIRST_COLUMN_X, DOWN_Y); // first column down

            public static Vector2 SECOND_COLUMN_UP = new Vector2(SECOND_COLUMN_X, UP_Y);  // second column up
            public static Vector2 SECOND_COLUMN_MID = new Vector2(SECOND_COLUMN_X, MID_Y); // second column mid
            public static Vector2 SECOND_COLUMN_DOWN = new Vector2(SECOND_COLUMN_X, DOWN_Y); // second column down

            public static Vector2 THIRD_COLUMN_UP = new Vector2(THIRD_COLUMN_X, UP_Y);  // third column up
            public static Vector2 THIRD_COLUMN_MID = new Vector2(THIRD_COLUMN_X, MID_Y); // third column mid
            public static Vector2 THIRD_COLUMN_DOWN = new Vector2(THIRD_COLUMN_X, DOWN_Y); // third column down

            public static Vector2 RIGHT_END = new Vector2(CENTER_X + 432, CENTER_Y + 11); // right end
        
    }
}
