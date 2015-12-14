using System;
using System.Collections.Generic;
using Dungen.Characters.GoodGuys;
using Dungen.Interfaces;
using Dungen.Magic;
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
        private Texture2D background; // Initialize field for warrior image
        private GoodGuys myMage;
        private List<IDrawMagic> magics;
        private DrawMagic myMagic;
        private float timeSinceLastChange = 0f; //for counting the seconds
        private KeyboardState mprevious;
        private float lastX;
        private float lastY;

        public GameEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void LoadContent()
        {
            magics = new List<IDrawMagic>();
            myMage = new Mage("Misho");
            magicType = Content.Load<Texture2D>("TextureAtlases/Fire");
            myMage.LoadContent(Content);
            background = Content.Load<Texture2D>("TextureAtlases/amarati");
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
            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White); //IMPORTANT! First draw background

            foreach (var drawMagic in magics)
            {
                drawMagic.Draw(spriteBatch);
            }


            myMage.Draw(spriteBatch);
            base.Draw(gameTime);
            spriteBatch.End();
        }

        private string CharacterState(float x, float y)
        {
            if (x != lastX)
            {
                if (x > lastX)
                {
                    return "Right";
                }
                return "Left";
            }
            if (y != lastY)
            {
                if (y > lastY)
                {
                    return "Up";
                }
            }
            return "Down";

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
