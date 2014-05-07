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
    public class MoveObj : CodeBaseClass
    {
        public bool leftClick
        {
            get { return currentState.LeftButton == ButtonState.Pressed;  }
        }

        public bool newLeftClick
        {
            get { return previousState.LeftButton == ButtonState.Released && currentState.LeftButton == ButtonState.Pressed; }
        }

        public bool leftRelease
        {
            get { return !leftClick && previousState.LeftButton == ButtonState.Pressed;  }
        }

    }
}
