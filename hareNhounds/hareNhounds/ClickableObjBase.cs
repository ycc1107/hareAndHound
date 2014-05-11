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
     public class ClickableObjBase
    {
        protected Texture2D _image;
        protected Vector2 _positon;
        protected Vector2 _positionIndex;
        protected bool _selected;
        protected bool _enable;

        public Texture2D setImage 
        { 
            set { _image = value; }
            get { return _image; }
        }

        public virtual Rectangle Area 
        {
            get { return new Rectangle((int)this.MovePosition.X, (int)this.MovePosition.Y, 50, 50); } 
        }

        public virtual bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }

        public virtual Vector2 MovePosition 
        {
            set { _positionIndex = value; }
            get { return _positionIndex; } 

        }

        public virtual Vector2 Position
        {
            set { _positon = value; }
            get { return _positon; }

        }

        public bool Selected
        {
            set{ _selected = value;}
            get{ return _selected; }
        }

        public void isClick(Point mousePosition)
        {
            if (this.Area.Contains(mousePosition) && !this.Selected && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.Selected = true;
            }
        }

        

    }
}
