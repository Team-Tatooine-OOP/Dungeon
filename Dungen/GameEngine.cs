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

namespace Dungen
{
    public class GameEngine : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D magicType;
        private MenuComponent menuComponent;
        private SpriteFont font;
        //private Texture2D bot;
        //private Texture2D villian; // Initialize field for villian image
        //private Texture2D warrior; // Initialize field for warrior image
        private Texture2D pixel; // Initialize field for warrior image
        private Texture2D background;
        private Texture2D background2;
        private GoodGuys myMage;
        private List<IDrawMagic> magics;
        private DrawMagic myMagic;
        private float timeSinceLastChange = 0f; //for counting the seconds
        private Texture2D menuBackground;
        private KeyboardState mprevious;
        private float lastX;
        private float lastY;
        private string equalsState = "Down";
        private string state;

        int mAlphaValue = 255;
        int mFadeIncrement = 2;
        double mFadeDelay = .035;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
            string[] menuItems = { "Start Game", "High Scores", "End Game" };

            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font/font");
            menuComponent = new MenuComponent(this,spriteBatch, font, menuItems, Content);
            Components.Add(menuComponent);
            magics = new List<IDrawMagic>();
            myMage = new Mage("Misho");
            magicType = Content.Load<Texture2D>("TextureAtlases/Fire");
            myMage.LoadContent(Content);
            pixel = Content.Load<Texture2D>("TextureAtlases/blackPixel");
            background = Content.Load<Texture2D>("TextureAtlases/Backround1");
            background2 = Content.Load<Texture2D>("TextureAtlases/Backround2");
            this.spriteBatch = new SpriteBatch(GraphicsDevice);
            myMagic = new MageMagic(magicType);
            myMagic.LoadContent(Content);

        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                 || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            lastX = myMage.movingVector2.X;
            lastY = myMage.movingVector2.Y;
            myMage.Update(gameTime);
            timeSinceLastChange += (float)gameTime.ElapsedGameTime.TotalSeconds; //second
            string lastState = CharacterState(myMage.movingVector2.X, myMage.movingVector2.Y);
            UpdateBullet(gameTime, lastState);

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
            if (menuComponent.IsPlayed == true)
            {
                this.spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White * 0.1f); //IMPORTANT! First draw background

                spriteBatch.Draw(pixel, new Rectangle(0, 0, 800, 480),
                    new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));

                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White * 0.03f);

                //spriteBatch.Draw(pixel, new Rectangle(0, 0, 800, 480), Color.Black);

                //spriteBatch.Draw(pixel, new Rectangle(0, 0, 800, 480),
                //    new Color(255, 255, 255, (byte)MathHelper.Clamp(mAlphaValue, 0, 255)));

                //spriteBatch.Draw(background2, new Rectangle(0, 0, 800, 480), Color.White * 0.03f);

                foreach (var drawMagic in magics)
                {
                    drawMagic.Draw(spriteBatch);
                }


                myMage.Draw(spriteBatch);
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }

        private string CharacterState(float x, float y)
        {

            if (x == lastX && y == lastY)
            {
                state = equalsState;
            }
            if (x != lastX)
            {
                if (x > lastX)
                {
                    state = "Right";
                }
                else
                {
                    state = "Left";
                }
            }
            if (y != lastY)
            {
                if (y > lastY)
                {
                    state = "Up";
                }
                else
                {
                    state = "Down";

                }
            }
            equalsState = state;
            return state;
        }

        public void UpdateBullet(GameTime gameTime, string state)
        {
            KeyboardState fireState = Keyboard.GetState();
            foreach (var drawMagic in magics)
            {
                drawMagic.Update(gameTime);
            }
            if (fireState.IsKeyDown(Keys.Space) && mprevious.IsKeyDown(Keys.Space) == false)
            {
                myMagic = new MageMagic((int)myMage.movingVector2.X, (int)myMage.movingVector2.Y, magicType, state);
                magics.Add(myMagic);
            }
            mprevious = fireState;
        }
    }
}
