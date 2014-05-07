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
    class Anima : CodeBaseClass
    {
        #region Private field

        private Rectangle playArea;

        private int result;


        #endregion 

        public Rectangle getPlayArea(Rectangle area) 
        {

            get{ return playArea;}

        }

        public Anima()
        {
            hareArea = new Rectangle((int)harePosition.X, (int)harePosition.Y, 50, 50);
            hound1Area = new Rectangle((int)hound1Position.X, (int)hound1Position.Y, 50, 50);
            hound2Area = new Rectangle((int)hound2Position.X, (int)hound2Position.Y, 50, 50);
            hound3Area = new Rectangle((int)hound3Position.X, (int)hound3Position.Y, 50, 50);
        }

        public int CheckTouch()
        {
            if (hareArea.Contains(mousePosiiton))
            {
                result = ReturnPosition.inHare;
            }
            else if (hound1Area.Contains(mousePosiiton))
            {
                result = ReturnPosition.inHound1;
            }
            else if (hound2Area.Contains(mousePosiiton))
            {
                result = ReturnPosition.inHound2;
            }
            else if (hound3Area.Contains(mousePosiiton))
            {
                result = ReturnPosition.inHound3;
            }

            return result;
        }
    }
}
