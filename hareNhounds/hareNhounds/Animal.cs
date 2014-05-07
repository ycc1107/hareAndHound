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
    public class Animal
    {
        private Texture2D _image;
        private Rectangle _area;
        private Vector2 _positon;
        private bool _selected;
        private bool _enable;
        

        public Animal()
        {
            _selected = false;
            _enable = false;
        }

        public Texture2D setImage 
        { 
            set { _image = value; }
            get { return _image; }
        }

        public virtual Rectangle Area 
        {
            set { _area = value; }
            get { return _area; } 
        }

        public virtual bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
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
