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
    class MoveObj : Game1
    {
        public MoveObj()
        {
            MouseState mouseState = new MouseState();
            var mousePosiiton = new Point(mouseState.X, mouseState.Y);


            Rectangle hareArea = new Rectangle((int)harePosition.X, (int)harePosition.Y, 40, 40);

            if (hareArea.Contains(mousePosiiton))
            {
                hare = Content.Load<Texture2D>("image/hound");
            }
            else
            {

            }


        }

    }
}
