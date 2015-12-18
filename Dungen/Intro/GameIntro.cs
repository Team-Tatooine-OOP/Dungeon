using System;
using System.Collections.Generic;
using Dungen.Characters.GoodGuys;
using Dungen.Interfaces;
using Dungen.Magic;
using Dungen.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OopProject.Characters.GoodGuys;

namespace Dungen.Intro
{
    internal class GameIntro : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D pixel;

        private Texture2D intro1;

        private Texture2D intro2;

        private int mAlphaValue = 255;

        private int mFadeIncrement = 2;

        private double mFadeDelay = .035;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("TextureAtlases/blackPixel");
            intro1 = Content.Load<Texture2D>("TextureAtlases/Backround1");
            intro2 = Content.Load<Texture2D>("TextureAtlases/Backround2");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            mFadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            if (mFadeDelay <= 0)
            {
                mFadeDelay = .035;
                mAlphaValue -= mFadeIncrement;
                if (mAlphaValue <= 0)
                {
                    mFadeIncrement *= -1;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(0, 0, 800, 480),
                new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));

            spriteBatch.Draw(intro1, new Rectangle(0, 0, 800, 480), Color.White);


            //this.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White * 0.1f); 
            //spriteBatch.Draw(pixel, new Rectangle(0, 0, 800, 480),
            //    new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));

            //spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White * 0.03f);

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
