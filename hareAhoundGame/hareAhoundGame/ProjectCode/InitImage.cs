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
       
    public class InitImage : Microsoft.Xna.Framework.Game
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

        protected Vector2[] boardSpotPosition = new Vector2 [12];

        public void init()
        {

            harePosition = Vector2.Zero;
            hound1Position = Vector2.Zero;
            hound2Position = Vector2.Zero;
            hound3Position = Vector2.Zero;
            backgroundPosition = Vector2.Zero;
        }

        public void beginStage()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("image/Hare_and_Hounds_board");
            hare = Content.Load<Texture2D>("image/hare");
            hound1 = Content.Load<Texture2D>("image/hound");
            hound2 = Content.Load<Texture2D>("image/hound");
            hound3 = Content.Load<Texture2D>("image/hound");

            #region TheBoardPositons

            float centerX = (graphics.GraphicsDevice.Viewport.Width - background.Width) / 2;
            float centerY = (graphics.GraphicsDevice.Viewport.Height - background.Height) / 2;
            float firstColumnX = centerX + 108;
            float secondColumnX = centerX + 215;
            float thirdColumnX = centerX + 325;
            float upY = 0;
            float midY =  centerY + 12;
            float downY = background.Height - 75;


            boardSpotPosition[0] = new Vector2(centerX, 0);  // board position

            boardSpotPosition[1] = new Vector2(centerX, centerY + 12); // left end

            boardSpotPosition[2] = new Vector2(firstColumnX, upY);  // first column up
            boardSpotPosition[3] = new Vector2(firstColumnX, midY); // fist column mid
            boardSpotPosition[4] = new Vector2(firstColumnX, downY); // first column down

            boardSpotPosition[5] = new Vector2(secondColumnX, upY);  // second column up
            boardSpotPosition[6] = new Vector2(secondColumnX, midY); // second column mid
            boardSpotPosition[7] = new Vector2(secondColumnX, downY); // second column down

            boardSpotPosition[8] = new Vector2(thirdColumnX, upY);  // third column up
            boardSpotPosition[9] = new Vector2(thirdColumnX, midY); // third column mid
            boardSpotPosition[10] = new Vector2(thirdColumnX, downY); // third column down

            boardSpotPosition[11] = new Vector2(centerX + 432, centerY + 11); // right end

            #endregion 

            backgroundPosition = boardSpotPosition[0];
            harePosition = boardSpotPosition[11];
            hound1Position = boardSpotPosition[1];
            hound2Position = boardSpotPosition[2];
            hound3Position = boardSpotPosition[4];

 

        
             
        }


    }
}
