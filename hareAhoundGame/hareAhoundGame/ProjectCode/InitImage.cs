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

    public class InitImage : CodeBaseClass
    {
        public void init()
        {
            this.IsMouseVisible = true;
            charatMovement = new MoveObj();
            mouseState = new MouseState();

            harePosition = Vector2.Zero;
            hound1Position = Vector2.Zero;
            hound2Position = Vector2.Zero;
            hound3Position = Vector2.Zero;
            backgroundPosition = Vector2.Zero;
        }

        public void beginStage()
        {
            background = Content.Load<Texture2D>("image/Hare_and_Hounds_board");
            hare = Content.Load<Texture2D>("image/hare");
            hound1 = Content.Load<Texture2D>("image/hound");
            hound2 = Content.Load<Texture2D>("image/hound");
            hound3 = Content.Load<Texture2D>("image/hound");

            #region old
            /*
            centerX = (graphics.GraphicsDevice.Viewport.Width - background.Width) / 2;
            centerY = (graphics.GraphicsDevice.Viewport.Height - background.Height) / 2;
            firstColumnX = centerX + 108;
            secondColumnX = centerX + 215;
            thirdColumnX = centerX + 325;
            upY = 0;
            midY = centerY + 12;
            downY = background.Height - 75;

            Console.WriteLine(firstColumnX+" "+secondColumnX+ " "+thirdColumnX+" "+upY+" "+midY+" "+downY);
            */
            #endregion

            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            backgroundPosition = BoardPosition.BOARD;
            harePosition = BoardPosition.RIGHT_END;
            hound1Position = BoardPosition.FIRST_COLUMN_UP ;
            hound2Position = BoardPosition.LEFT_END;
            hound3Position = BoardPosition.FIRST_COLUMN_DOWN;
        }

    }
}
