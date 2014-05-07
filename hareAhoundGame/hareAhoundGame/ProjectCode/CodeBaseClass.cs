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
    public class CodeBaseClass : Microsoft.Xna.Framework.Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        protected Texture2D hare;
        protected Texture2D hound1;
        protected Texture2D hound2;
        protected Texture2D hound3;
        protected Texture2D background;

        protected Vector2 harePosition;
        protected Vector2 hound1Position;
        protected Vector2 hound2Position;
        protected Vector2 hound3Position;
        protected Vector2 backgroundPosition;

        protected MouseState currentState;
        protected MouseState previousState;
        protected Point mousePosition;

        protected MoveObj charatMovement;
    }
}
